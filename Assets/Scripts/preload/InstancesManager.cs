using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/* Classe criada baseado no padr�o de projeto Singleton.
 * Seu intuito � guardar e fornecer inst�ncias de classes �nicas presentes em cada scene do jogo.
 * Diminuindo o n�mero de chamadas do m�todo FindObjectOfType.
 * Caso a inst�ncia n�o exista no singleton, o mesmo ir� buscar essa inst�ncia e salvar em seu objeto est�tico.
 */
public class InstancesManager : MonoBehaviour
{
    public static InstancesManager singleton;
    [SerializeField] private GarmentSkins garment_Skins;
    //private GameObject player;

    void Awake()
    {
        if (singleton != null)
            Destroy(singleton);
        else
            singleton = this;

        DontDestroyOnLoad(this);
    }

    //M�todo respons�vel por retornar o GameObject do jogador para quem solicitar
    //Caso o GameObject n�o exista no singleton, procure pelo mesmo, salve e retorne (isso ocorre uma vez por game)
    /*public PlayerController GetPlayerInstance()
    {
        if (player == null)
        {
            var aux = FindObjectOfType<PlayerController>();

            //Se n�o achar � pq essa � a primeira scene a ser carregada no game, ent�o o GameController ir� criar o prefab na scene
            if (aux != null)
                player = aux.gameObject;
        }

        return player;
    }*/

    //M�todo respons�vel por retornar o DialogueRunner do _preload para quem solicitar
    //Caso o DialogueRunner n�o exista no singleton, procure pelo mesmo, salve e retorne (isso ocorre uma vez por cena)
    public GarmentSkins GetGarmentSkinsInstance()
    {
        if (garment_Skins == null)
            garment_Skins = FindObjectOfType<GarmentSkins>();

        return garment_Skins;
    }
}
