using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class HexagonGridManager : MonoBehaviour
{
    public static float HorizontalDiameter { get; } = 3f;
    public static float VerticalDiameter { get; } = 4f;

    //
    // INSPECTOR VALUES
    #region inspector_values
    [SerializeField] LayerMask fieldMask = default;
    [SerializeField] Camera targetCamera = default;

    [Header("Selector")]
    [SerializeField] Transform selector = default;
    [SerializeField] Material selectorMaterialNeutral = default;
    [SerializeField] Material selectorMaterialNegative = default;
    [SerializeField] Material selectorMaterialWalk = default;
    [SerializeField] Material selectorMaterialAttack = default;
    [SerializeField] Material selectorMaterialRange = default;

    // TODO: replace this with loader
    [SerializeField] List<Piece> pieces = default;
    #endregion

    //
    // EVENTS
    #region events

    public UntityVector3Event onSelectorPositionChange;
    public UnityPieceEvent onSelectedPieceChange;

    #endregion

    //
    // PRIVATE FIELDS
    #region private_fields

    List<CellBehaviour> cells;

    PlayingFieldControls controls;
    Vector3 _hoveredPosition;
    Piece _selectedPiece;

    #endregion

    //
    // MONOBEHAVIOUR METHODS
    #region monobehaviour_methods

    void Awake()
    {
        controls = new PlayingFieldControls();

        cells = new List<CellBehaviour>();
        foreach (var cell in GetComponentsInChildren<CellBehaviour>())
        {
            cells.Add(cell);
        }
    }

    void Start()
    {
        foreach (var piece in pieces)
        {
            var cell = CellAtPosition(piece.StartPosition);

            if (cell != null)
            {
                piece.transform.position = cell.GetWorldPosition();
            }
        }
    }

    void OnEnable()
    {
        controls.PlayField.Enable();

        controls.PlayField.SelectTile.performed += OnSelectTile;
    }

    void OnDisable()
    {
        controls.PlayField.SelectTile.performed -= OnSelectTile;

        controls.PlayField.Disable();
    }

    void Update()
    {
        UpdateSelector();
    }

    #endregion

    //
    // CONTROL LISTENERS
    #region control_listeners
    void OnSelectTile(InputAction.CallbackContext ctx)
    {
        // TODO: Check who's turn it is, etc
        if (_selectedPiece == null)
        {
            _selectedPiece = GetPieceAtPosition(_hoveredPosition);

            onSelectedPieceChange?.Invoke(_selectedPiece);
        }
        else if (_selectedPiece != null)
        {
            var cell = CellAtPosition(_hoveredPosition);

            if (cell != null)
            {
                ActionState state = _selectedPiece.DoAction(_hoveredPosition, GetPieceAtPosition(_hoveredPosition));
                bool didAction = false;


                Debug.Log("DO ACTION " + state.ToString());

                if (state == ActionState.Negative)
                {
                    didAction = false;
                }
                else if (state == ActionState.Walk)
                {
                    _selectedPiece.transform.position = cell.GetWorldPosition();

                    didAction = true;
                }
                else if (state == ActionState.Attack)
                {
                    didAction = true;
                }
                else if (state == ActionState.Range)
                {
                    didAction = true;
                }

                if (didAction)
                {
                    foreach (var piece in pieces)
                    {
                        if (piece != _selectedPiece)
                            piece.CheckActionOnPiece(_selectedPiece);
                    }

                    _selectedPiece = null;
                }
            }
        }
    }
    #endregion

    //
    // CLASS METHODS
    #region class_methods

    void UpdateSelector()
    {
        Vector3 selectorPosition = MouseLocationToGridPosition();

        if (selectorPosition != _hoveredPosition)
        {
            _hoveredPosition = selectorPosition;
            onSelectorPositionChange?.Invoke(_hoveredPosition);

            selector.position = MouseLocationToWorldPosition();

            var meshRenderer = selector.GetComponent<MeshRenderer>();

            Debug.Log("changed");

            if (_selectedPiece != null)
            {
                ActionState state = _selectedPiece.CanDoAction(_hoveredPosition, GetPieceAtPosition(_hoveredPosition));

                Debug.Log(state.ToString());

                if (state == ActionState.Neutral)
                {
                    meshRenderer.material = selectorMaterialNeutral;
                }
                else if (state == ActionState.Walk)
                {
                    meshRenderer.material = selectorMaterialWalk;
                }
                else if (state == ActionState.Negative)
                {
                    meshRenderer.material = selectorMaterialNegative;
                }
                else if (state == ActionState.Attack)
                {
                    meshRenderer.material = selectorMaterialAttack;
                }
                else if (state == ActionState.Range)
                {
                    meshRenderer.material = selectorMaterialRange;
                }
            }
            else
            {
                meshRenderer.material = selectorMaterialNeutral;
            }
        }
    }

    Vector3 MouseLocationToWorldPosition()
    {
        RaycastHit info;
        Ray ray = targetCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out info, float.MaxValue, fieldMask))
        {
            if (info.transform.TryGetComponent(out CellBehaviour cellBehaviour))
            {
                return cellBehaviour.GetWorldPosition();
            }
        }

        return new Vector3(0, -1, 0);
    }

    Vector3 MouseLocationToGridPosition()
    {
        RaycastHit info;
        Ray ray = targetCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out info, float.MaxValue, fieldMask))
        {
            if (info.transform.TryGetComponent(out CellBehaviour cellBehaviour))
            {
                return cellBehaviour.GetGridPosition();
            }
        }

        return Vector2.zero;
    }

    Piece GetPieceAtPosition(Vector3 pos)
    {
        foreach (var piece in pieces)
        {
            if (piece.CurrentGridPosition() == pos)
            {
                return piece;
            }
        }

        return null;
    }

    CellBehaviour CellAtPosition(Vector3 pos)
    {
        return cells.FirstOrDefault(i => i.GetGridPosition() == pos);
    }

    #endregion
}
