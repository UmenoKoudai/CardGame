using UnityEngine;

public class TurnSubscribe : MonoBehaviour
{
    private void OnEnable()
    {
        TurnManager._onBeginTurn += OnBeginTurn;
        TurnManager._onEndTurn += OnEndTurn;
    }

    private void OnDisable()
    {
        TurnManager._onBeginTurn -= OnBeginTurn;
        TurnManager._onEndTurn -= OnEndTurn;
    }
    public virtual void OnBeginTurn()
    {
        Debug.LogError("�^�[���J�n���̏������I�[�o�[���C�h����Ă��܂���");
    }
    public virtual void OnEndTurn()
    {
        Debug.LogError("�^�[���I�����̏������I�[�o�[���C�h����Ă��܂���");
    }
}
