using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/* Classe criada baseado no padrão de projeto Singleton.
 * Seu intuito é guardar e fornecer instâncias de classes únicas presentes em cada scene do jogo.
 * Diminuindo o número de chamadas do método FindObjectOfType.
 * Caso a instância não exista no singleton, o mesmo irá buscar essa instância e salvar em seu objeto estático.
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

    //Método responsável por retornar o GameObject do jogador para quem solicitar
    //Caso o GameObject não exista no singleton, procure pelo mesmo, salve e retorne (isso ocorre uma vez por game)
    /*public PlayerController GetPlayerInstance()
    {
        if (player == null)
        {
            var aux = FindObjectOfType<PlayerController>();

            //Se não achar é pq essa é a primeira scene a ser carregada no game, então o GameController irá criar o prefab na scene
            if (aux != null)
                player = aux.gameObject;
        }

        return player;
    }*/

    //Método responsável por retornar o DialogueRunner do _preload para quem solicitar
    //Caso o DialogueRunner não exista no singleton, procure pelo mesmo, salve e retorne (isso ocorre uma vez por cena)
    public GarmentSkins GetGarmentSkinsInstance()
    {
        if (garment_Skins == null)
            garment_Skins = FindObjectOfType<GarmentSkins>();

        return garment_Skins;
    }
}
