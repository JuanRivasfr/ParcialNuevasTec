using UnityEngine;
using UnityEngine.Tilemaps;

public class PuertaTilemap : MonoBehaviour
{
    [Header("Tilemap y Tiles")]
    public Tilemap tilemap;
    public TileBase puertaCerradaArriba;
    public TileBase puertaCerradaAbajo;
    public TileBase puertaAbiertaArriba;
    public TileBase puertaAbiertaAbajo;

    [Header("Configuración")]
    public Vector3Int posicionSuperior;
    private bool abierta = false;
    private bool jugadorCerca = false;

    private TilemapCollider2D tileCollider;

    void Start()
    {
        tileCollider = tilemap.GetComponent<TilemapCollider2D>();
    }

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            CambiarPuerta();
        }
    }

    void CambiarPuerta()
    {
        abierta = !abierta;
        Vector3Int posInferior = posicionSuperior + new Vector3Int(0, -1, 0);

        if (abierta)
        {
            // 🔓 Puerta abierta: cambiar sprites y quitar colisión
            tilemap.SetTile(posicionSuperior, puertaAbiertaArriba);
            tilemap.SetTile(posInferior, puertaAbiertaAbajo);

            tilemap.SetColliderType(posicionSuperior, Tile.ColliderType.None);
            tilemap.SetColliderType(posInferior, Tile.ColliderType.None);
        }
        else
        {
            // 🔒 Puerta cerrada: restaurar tiles y colisión
            tilemap.SetTile(posicionSuperior, puertaCerradaArriba);
            tilemap.SetTile(posInferior, puertaCerradaAbajo);

            tilemap.SetColliderType(posicionSuperior, Tile.ColliderType.Grid);
            tilemap.SetColliderType(posInferior, Tile.ColliderType.Grid);
        }

        // 🔁 Refrescar visualmente los tiles
        tilemap.RefreshAllTiles();

        // 🔧 Forzar regeneración completa del collider
        if (tileCollider != null)
        {
            // Desactiva y reactiva para actualizarlo
            tileCollider.enabled = false;
            // ⚠️ Espera un frame para que Unity aplique los cambios
            StartCoroutine(ReactivarCollider());
        }
    }

    private System.Collections.IEnumerator ReactivarCollider()
    {
        yield return null; // Espera 1 frame
        tileCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            jugadorCerca = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            jugadorCerca = false;
    }
}
