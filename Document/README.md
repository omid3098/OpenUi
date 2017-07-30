Open Sampel scene. there is a single ui-manager object that controls which menu type should be loaded as main menu.
We have two major kinds of ui elements. Window and Modal. A window is used for each state of your app/game while a modal is shown inside each window.
you can not see more than one window at a time but you can see any number of modals in each window.
ie1: You want to show a popup to user and ask "Are you sure? Yes/No" in shop, in this scenario, popup is a modal and shop menu is Window.
ie2: You want to show coin count both in main menu and shop, you can put coin ui elements inside main menu and shop menu separately, but the best approach is to have a single coin-modal and use it in every place you want. so when coin elements need a change, you only change it once in its own modal.

Add new Window:
    - Open WindowType.cs
    - Add/Remove your Window types.
    - Make your window Ui in unity editor, add "Window" component, set window type.
    - Make a prefab of your window at "Resources/window/" (you can change this path in UiManagerSetting.cs)

Add new Modal:
    - Open ModalType.cs
    - Add/Remove your modal types.
    - make your modal Ui in unity editor, add "Modal" component, set modal type.
    - Make a prefab of your modal at "Resources/modal/" (you can change this path in UiManagerSetting.cs)

Change Window:
    - If you have a button, just Add ChangeWindowButton component on your button.
    - or call:
        UiManager.instance.ChangeWindow(WindowType windowType);

Show/Hide Modal:
    - If you have a button, just Add ShowModalButton or HideModalButton component on your button.
    - or call:
        UiManager.instance.ShowModal(ModalType modalType);
        UiManager.instance.HideModal(ModalType modalType);

#Requirements:
    - prime31 ZestKit tween library. (https://github.com/prime31/ZestKit)