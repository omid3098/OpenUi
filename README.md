# OpenUi

![openui_](https://user-images.githubusercontent.com/6388730/28753995-eae2fbfe-7551-11e7-8d2f-421ed6012cd6.gif)


An easy to use Ui-Kit for Unity.


Open Sampel scene. there is a single ui-manager object that controls which menu type should be loaded as main menu.
We have two major kinds of ui elements. Window and Modal. A window is used for each state of your app/game while a modal is shown inside each window.
you can not see more than one window at a time but you can see any number of modals in each window.
ie1: You want to show a popup to user and ask "Are you sure? Yes/No" in shop, in this scenario, popup is a modal and shop menu is Window.
ie2: You want to show coin count both in main menu and shop, you can put coin ui elements inside main menu and shop menu separately, but the best approach is to have a single coin-modal and use it in every place you want. so when coin elements need a change, you only change it once in its own modal.

### Add new Window:
1. Open WindowType.cs
2. Add/Remove your Window types.
3. Make your window Ui in unity editor, add "Window" component, set window type.
4. Make a prefab of your window at "Resources/window/" (you can change this path in UiManagerSetting.cs)

### Add new Modal:
1. Open ModalType.cs
2. Add/Remove your modal types.
3. make your modal Ui in unity editor, add "Modal" component, set modal type.
4. Make a prefab of your modal at "Resources/modal/" (you can change this path in UiManagerSetting.cs)

### Change Window:
1. If you have a button, just Add ChangeWindowButton component on your button.
2. or call:

      ```
      UiManager.instance.ChangeWindow(WindowType windowType);
      ```

### Show/Hide Modal:
1. If you have a button, just Add ShowModalButton or HideModalButton component on your button.
2. or call:

    ```
    UiManager.instance.ShowModal(ModalType modalType);
    UiManager.instance.HideModal(ModalType modalType);
    ```
### Transisions:
Scale: (x/y/both)

![openui_scale](https://user-images.githubusercontent.com/6388730/28754250-07c280c8-7557-11e7-93fe-44a4fec0d3c5.gif)

Slide: (up/down/left/right)

![openui_slide](https://user-images.githubusercontent.com/6388730/28754251-07f62d1a-7557-11e7-88da-3b25f4b00b27.gif)

Fade: (in/out)

![openui_fade](https://user-images.githubusercontent.com/6388730/28754249-07b6e83a-7557-11e7-9b4c-1a28e973523c.gif)


### Requirements:
* prime31 ZestKit tween library. (https://github.com/prime31/ZestKit)
