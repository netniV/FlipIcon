   M S B A M L   `   `   `  ����^  ZAttachedCommandBehavior, Version=1.0.1.0, Culture=neutral, PublicKeyToken=d2f24b6632eaf900bFclr-namespace:AttachedCommandBehavior;assembly=AttachedCommandBehaviorAttachedCommandBehavior  5   	   O KFlipIcon, Version=0.2.1.0, Culture=neutral, PublicKeyToken=6e63ad01286bf8263clr-namespace:FlipIcon.HandlerFlipIcon.Handler 5   	   7 clr-namespace:FlipIcon.SelectorsFlipIcon.Selectors 5   	   9!clr-namespace:FlipIcon.ViewModelsFlipIcon.ViewModels 5
   	   3clr-namespace:FlipIcon.WindowsFlipIcon.Windows 5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L5clr-namespace:System.Diagnostics;assembly=WindowsBaseSystem.Diagnostics 5   	   !   FlipIcon.Windows.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   VacbFclr-namespace:AttachedCommandBehavior;assembly=AttachedCommandBehavior     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   ,hclr-namespace:FlipIcon.Handler     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .s clr-namespace:FlipIcon.Selectors     5   	   h dHardcodet.Wpf.TaskbarNotification, Version=1.0.6.0, Culture=neutral, PublicKeyToken=1d291c1370f35861)tb http://www.hardcodet.net/taskbar  5	   	   *vm!clr-namespace:FlipIcon.ViewModels  5
   	   &wclr-namespace:FlipIcon.Windows  5   	   Y UXceed.Wpf.DataGrid, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xctk*http://schemas.xceed.com/wpf/xaml/datagrid  5   	   @diag5clr-namespace:System.Diagnostics;assembly=WindowsBase  5   	   -   5          �Name$  
mainWindow��5   	    � Title$ 
MainWindow��5   	   $	��355��5   	    � AllowsTransparency . 
 � Top$ 0��5   	    � WindowStyle$
 None=�5   	    � DataContext 5      '  !FlipIcon.ViewModels.MainViewModel  5   
   -   5        	viewModel��5      ��5      �� 5   
    �� Opacity$	 0.0Q�6    �� Color$ Black��6(    � 	Resources 5         TranslucentScrollBarStyle	 �� 
TargetType
 �� Triggers P� Property P� Value �� Property �� Value �� 
TargetType � ColumnDefinitions � RowDefinitions �� ScrollableHeight � Maximum �� ViewportHeight �� ViewportSize* �� #ComputedVerticalScrollBarVisibility �� VerticalOffset � Value �� ScrollableWidth �� Orientation �� ViewportWidth, �� %ComputedHorizontalScrollBarVisibility �� HorizontalOffset  	GridItems �� Source �� ElementName  �� Path  GroupedChildMenu  UngroupedChildMenu-  'System.Windows.Data.CompositeCollection  MenuCollection! �� 
Collection" �� Source%  System.Windows.Markup.Reference# m�Name$ m� Command
% � Tag& m� 	IsChecked  ConnectionDataTemplate' �� FallbackValue( �� Orientation��%�  &	        '�� �     7   7   &	 �    &	 �    &	 /    &	 �    7  7  &	 �    (�� 4    5�      *!SystemColors.WindowTextColorKey+)�� 5   
   "	 ��62   
 5      P� 5        �@J�IsMouseOver . . �5!      ��  �@J�Opacity$	 0.9Q�60   5"      P� 5#       �@J�IsMouseOver .  . �5$      ��  �@J�Opacity$	 0.4Q�60   5%      5'      �� 5)   
   "	 ��6   .�5*      ��  �@�OverridesDefaultStyle . 66   �� 5+       � �� 5,      �� 5-      " ��6&   .R�5.      �  5/      �� 50   "   $��* �63   �� 51   "   $
��Auto �63    53      �� 54   "   $��* �60   �� 55   "   $
��Auto �60   .+�57      �� $��2��65   $��2��6F   �� 58      $��PART_VerticalScrollBar��6(   $��1��59   (   # z 5:   (   8��  # z 5<   (   #y�z 5=   (   # z 5>   (   �� 5?      $��PART_HorizontalScrollBar��6(   $��1��5@   (   # z 5A   (   $ 
Horizontal=�5B   (   8�� # z 5D   (   #y�z 5E   (   # z 5F   (   5G      5H      5J      5K      �� 5M   
    61   �� $ 
mainWindow��$  DataContext.Connections��� 5N   
    68   �� $ 
mainWindow��$"  DataContext.GroupedMenuItems��� 5O   
    6:   �� $ 
mainWindow��$$  DataContext.UngroupedMenuItems�  5Q   
   �� 5T      ! 6"   �� 8"   �� 5U      y�6   �� *)'DataContext.GroupingSeparatorVisibility+"   *
mainWindow+�� 5V      ! 6"   �� 8"  �� 5W      m� 5X      $# MenuItemVersion��6   $ 5Y      �� *DataContext.AboutMenuCommand+"   *
mainWindow+��5[      �� *DataContext.VersionInfo+"   *
mainWindow+�� 5]      y�6   �� *&$DataContext.ExtraMenuItemsVisibility+"   *
mainWindow+m� 5^      $# MenuItemStartup��6   $��Start with Windows��5a      $% StartupCommand��5e      $ 5_      �� *DataContext.StartupCommand+"   *
mainWindow+& 5b      �� *DataContext.StartupEnabled+"   *
mainWindow+��5d      Z� y�5f      �� *&$DataContext.ExtraMenuItemsVisibility+"   *
mainWindow+m� 5h      $# MenuItemExit��6   $
��Exit��5k      $% ExitApplicationCommand��5m      $ 5i      �� *$"DataContext.ExitApplicationCommand+"   *
mainWindow+��5l      Z� y�5n      �� *&$DataContext.ExtraMenuItemsVisibility+"   *
mainWindow+5p      �� 5r   
   .R�5s      � $��Stretch=�6    5t      �� 5u      $
��auto �6'   �� 5v      $��* �6'   ��5y      �� 5z      $	 0.0Q�6&   $ Black��64   .+�5}      �� $��0��6   $��5q�5~      
�������$��1q�5�      ._�5�      �� $��50��6   $��50��5�      $��Center=�5�      $��Center=�5�      $��Center=�5�      $��Center=�5�      $��16(�5�      
���������5�      �� $  Abbreviation�$' ??��5�      5�      � 5�      $��1��6   $��Stretch=�6'    5�      �� 5�      $��* �6+   �� 5�      $
��auto �6+   �� 5�      $��25 �6+   .+�5�      �� $��0��6!   $��5q�5�   !   $��Center=�5�   !   .+�5�      �� $( 
Horizontal=�6%   $��Normal"�6>   .+�5�      �� $��20(�6(   
���������5�   (   �� $  FullName�$' 	FirstName��5�      �� 5�      $��14(�6$   
���������5�   $   �� $  ConnectionStatus�$' Status���� 5�      $��10(�6$   
���������5�   $   �� $  PhoneNumber�$' Destination��5�      �� 5�      $��1��6!   $��Center=�61   .+�5�      �� $��1��6$   $��Center=�5�   $   $��Right=�5�   $   $��14(�5�   $   
���������5�   $   �� $  	EntryType�$' 	EntryType���� 5�      $��Center=�6$   $��14(�5�   $   
���������5�   $   �� $  VpnType�5�      5�      5�      5�      �� 5�   
   $ White��6M   5�      .��5�      ]� ��.  .+�5�   
   � -   5        ) �Name$) 
LayoutRoot��5�      $��Right=�5�      ��5�      �� $ 
mainWindow��$  Width���5�      �� $ 
mainWindow��$  Height���5�      �� 5�      $	 0.8Q�6"   $ Black��60    5�      �� 5�       5�      �� 5�      $
��auto �6    �� 5�      .+�5�      �� -   5        * ��Name$* connectionsListView��5�      $��Stretch=�5�      $��Stretch=�5�      #��[ 5�      $��Hidden=�5�      $
��Auto=�5�      ��5�      �� $ 
mainWindow��$  Height���5�      �� *Connections++ �� SelectedItem+ 5�      �� *SelectedConnection+��5�      �� 5�      "	 ��6   .�5�      ��  � ��$ Stretch=�6G   5�      ��5�      �� 5�      $	 0.0Q�6&   $ Black��64   7   1AttachedCommandBehavior.CommandBehaviorCollection,   	Behaviors, 5�      -   'AttachedCommandBehavior.BehaviorBinding  5�      -   Event$- MouseDoubleClick��5�   *   .   Command. 5�   *   �� *ConnectionCommand+/   CommandParameter/ 5�   *   �� $ connectionsListView��$  SelectedItem�5�   *   0 �� 
GroupStyle0 5�      (  "System.Windows.Controls.GroupStyle  5�      1   HeaderTemplate1 5�      �� 5�      .R�5�   "   �� .+�5�   &   �� ��60   �� $
  Name�5�   #   5�      2   ContainerStyle2 5�      �� 5�      "	 ��6$   .�5�   "   ��  � �� 5�   &   �� 5�   *   " ��6:   .R�5�   .   9� ��5�   2   �� 5�   6   $( 
Horizontal=�6A   .+�5�   :   �� ��6D   �� $
  Name��� 5�   :   ��6D   �� $  	ItemCount��� 5�   :   $��Items��6D   5�   7   .��5�   2   �� 5�   /   5�   +   5�   #   5�      5     5     3  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon  5     -   5        3  Name$3 
NotifyIcon��5     4   NoLeftClickDelay4 . 5   
IconSource5 5     �� *
IconSource+6   LeftClickCommand6 5     �� *ShowAppBarCommand+7   MenuActivation7 5     �� *MenuActivationMode+% 5     �� $ 	viewModel��8   ToolTipText8 5     �� *ConnectionStatus+$  FlipIcon.Handler.BalloonHelper9   CustomBalloon9 5     �� *	Balloon+:   StandardBalloon: 5     �� *
BalloonTip+, 5       5     $/ false��5  *   $- TrayLeftMouseDown��5  *   . 5  *   �� *#!SetExtraMenuItemsVisiblityCommand+5  *     5     $
/ true��5  *   $- TrayRightMouseDown��5  *   . 5  *   �� *#!SetExtraMenuItemsVisiblityCommand+5  *   ; � ContextMenu; 5     �� 5     -   5        < ��Name$< TaskbarContextMenu��5  "    5   "   �� $  PlacementTarget.Tag�= �� RelativeSource= �� *Self+��5"  "   �� #" [  5#     > �� Binding? �� Value1	  +System.Diagnostics.PresentationTraceSources@ 	  
TraceLevelA �� DataType+
  %FlipIcon.ViewModels.MenuItemViewModelB �� ItemsSource��%E  'm�       (�� �    50  7   *,
 +)�� 5$     "	 m�6$   
 5%  "   �� 5&  &   > 62   �� *Tag+? 6J   Z� .a�5'  *   ��  � �� 6C   �� *Header+�� 5(  *    � {� 6F   �� *	IsEnabled+�� 5)  *    �@m�IsCheckable 6H   �� *IsCheckable+�� 5*  *    �@m�	IsChecked 6F   �� *	IsChecked+$
@ High=��� 5+  *    �@m�CommandParameter 6M   �� �� 5,  *    �@m�Command 6D   �� *DataContext.FlipCommand+"   *
mainWindow+5-  '   5/     �� 50     "A 
 67   B 6`   �� *ChildMenuItems+51     52     54     55     56     57     