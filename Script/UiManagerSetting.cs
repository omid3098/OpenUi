namespace OpenUi
{
    public abstract class UiManagerSetting
    {
        public abstract string canvasPath { get; }// = "ui-canvas";
        public abstract string windowPath { get; }// = "window";
        public abstract string modalPath { get; }// = "modal";
        public abstract string buttonPath { get; }// = "button";
    }
}