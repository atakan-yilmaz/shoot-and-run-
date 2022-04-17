using shootandRun1.Abstracts.Uis;
using shootandRun1.Managers;

namespace shootandRun1.Uis
{
    public class StartButton : MyButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadLevel(name:"Game");
        }
    }
}