using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangePoint : MonoBehaviour
{
    public SceneManagement sceneManage; 

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.name == ("Border1") || this.gameObject.name == ("Border4")) { sceneManage.GoToLevel1(); }

        else if (this.gameObject.name == ("Border2") || this.gameObject.name == ("Border5")) { sceneManage.GoToLevel2(); }

        else if (this.gameObject.name == ("Border3") || this.gameObject.name == ("Border6")) {  sceneManage.GoToLevel3(); }

    }
}
