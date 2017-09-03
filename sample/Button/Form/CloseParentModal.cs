using OpenUi;

namespace OpenUi
{
    public class CloseParentModal : FormButton
    {
        protected override void Pressed()
        {
            base.Pressed();
            transform.parent.GetComponent<Modal<SampleModalType>>().Hide();
        }
    }
}