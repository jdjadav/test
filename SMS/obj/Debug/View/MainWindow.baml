   M S B A M L   `   `   `  ����  SMS    SMS.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;controls,http://metro.mahapps.com/winfx/xaml/controls  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=null:MD1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   
   ���#ecf0f5$��Medium"�5	   	   $��14(�5
   	   $��Cambria)�5   	     � Title$  
MainWindow��5   	   $	��800��6   (  "MahApps.Metro.Controls.MetroWindow   ShowTitleBar .  $
��1000��6>      ShowMaxRestoreButton .     ShowMinButton .     ShowCloseButton .   � WindowState$ 	Maximized=�6�   .��5      � ���#e6e6e6 � ColumnDefinitions 5      �� 5      $	��220 �6   �� 5      $��* �6   .+�5      )  #MaterialDesignThemes.Wpf.DialogHost  $��2��6      
Identifier$ 
RootDialog��6'   $��
0,-10,0,10q�6�      SnackbarMessageQueue 6?   �� 	 �� ElementName$	 MainSnackbar��
 �� Path$
 MessageQueue�.��5      )  #MaterialDesignThemes.Wpf.DrawerHost     IsLeftDrawerOpen 6   �� $	 MenuToggleButton��$
 	IsChecked�   LeftDrawerContent 5      ]� 5      $	��212��6   ���#3d91c2.+�5      d� 
������� ' #MaterialDesignHamburgerToggleButton#��[ 6(   $	��Top=�5   %   $��35��6:   $��35��6E   $��Right=�5   %   $��10q�6A    � Cursor$
 Hand��5   u    d� 	IsChecked 6%   �� $	 MenuToggleButton��$
 	IsChecked� �� Mode$ TwoWay=�6u   �� 5      -   5         ��Name$ DemoItemsListBox��5      
�������$��	0 16 0 16q�6=   ��5      �� *
DataList+��5    	   �� 5!   
   .R�5"      �� $
��Left=�6    �� Orientation$ 
Horizontal=�61   $
 Hand��6J   .+�5#      '  !MaterialDesignThemes.Wpf.PackIcon  $��28��6.   $��28��6:   $��10 0 0 0q�6E      Kind 6   �� *icon+6E   �� 5$      $��Cambria)�6,   $��23(�6A   $��10 0 0 0q�6O   ��6   �� *Name+6d   5%      5&      5)   	   5*      .��5-      ]� .+�5.      (  "MaterialDesignThemes.Wpf.ColorZone  $��15,0,0,0q�6   $��65��6'   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�63      Mode$ 
PrimaryMid=�5/   -   ���#3c8dbc$	��Top=�6T   .��50      ]� .+�51   	   d� -   5         d�Name$ MenuToggleButton��52   )   #��[ 51   X   $��40��6�   $
 Hand��6�   $��40��6�   $ FalseY�6�   $��0,8,0,0q�6�   y�6   �� *VisAll+ �� UpdateSourceTrigger$ PropertyChanged=�52   )   �� 53   	   $��Center=�6   $��Center=�60   $��22(�6K   6[   �� 54   	   -   5         ��Name$ btnClose��54      $ Depth0=�6"   $��Right=�6H    � ToolTip$ Close��6_   ���#cc0000���#cc0000$��0,0,0,0q�6�   $��67��6�   $��55��6�   $��Center=�6�   $��Right=�6�   $��2��6�   .��55   
     $ CloseCircle=�6   $��Center=�6)   $	��Top=�6F   $��0,5,0,0q�6^   $��27��6o   $��28��6{   $
��Bold"�6�   56   
   �� 57   	   -   5        $ btnMinimized��57      $ Depth0=�6&   $��Right=�6K   $ 	Minimized��6b   ���#00b386���#00b386$��0,0,2,0q�6�   $��67��6�   $��55��6�   $��Center=�6�   $��Right=�6�   $��2��6   .��58   
     $ ColorHelper=�6   $��Center=�6)   $	��Top=�6F   $��0,0,0,0q�6^   $��30��6o   $��30��6{   $
��Bold"�6�   59   
   '  !MaterialDesignThemes.Wpf.PopupBox  5:   	   $y�	Collapsed=�6   $��5,8,1,0q�6-   $��Right=�6>   $��Right=�6U   $��Center=�6q      PlacementMode$ BottomAndAlignRightEdges=�6�      	StaysOpen .     PopupContent. 5;   
   �� .+�5<      �� .��5=      �� $ 
Horizontal=�6   $��Center=�60   .+�5>        $
 Home=�6   $��Center=�6%   $��15(�6@   �� 5?      $��Company��6   $��Center=�6&   $��17(�6A   $��3,0,0,0q�6O   5@      5A      �� 5B      .��5C      �� $ 
Horizontal=�6   $��Center=�60   .+�5D        $ Account=�6   $��Center=�6(   $��15(�6C   �� 5E      $��UserProfile��6   $��Center=�6*   $��17(�6E   $��3,0,0,0q�6S   5F      5G      �� 5H      .��5I      �� $ 
Horizontal=�6   $��Center=�60   .+�5J        $ Logout=�6   $��Center=�6'   $��15(�6B   �� 5K      $��Logout��6   $��Center=�6%   $��17(�6@   $��3,0,0,0q�6N   5L      5M      5N      5O   
   5P   	   5Q      � 5S      .+�5T       � -   5          �Name$ 	MainFrame��5T      $��0,0,0,0q�6!     � NavigationUIVisibility$ Hidden=�62   ��.  5V   	   5W      5X      5Y      5Z      '  !MaterialDesignThemes.Wpf.Snackbar  5]      -   5          Name$ SnackbarThree��5]   ~   $��2��6   $��Right=�6%   $��Bottom=�6A      MessageQueue 6]   4	  .MaterialDesignThemes.Wpf.MessageQueueExtension	  6~   5_      5`      