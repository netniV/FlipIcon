   M S B A M L   `   `   `  ����O  KFlipIcon, Version=0.2.1.0, Culture=neutral, PublicKeyToken=6e63ad01286bf8263clr-namespace:FlipIcon.WindowsFlipIcon.Windows  5      .    (FlipIcon.Windows.ConnectionStatusBalloon   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:FlipIcon.Windows     5      h dHardcodet.Wpf.TaskbarNotification, Version=1.0.6.0, Culture=neutral, PublicKeyToken=1d291c1370f35861)tb http://www.hardcodet.net/taskbar  5      -   5          >�Name$  me��5	      $	��300��6+   $
��auto��6;   $
��auto��6H    � 	Resources 5
       
  FadeIn g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value  HighlightCloseButton  FadeCloseButton  FadeBack  FadeOut��%�  &	        &	     &	 �    &	 �    &	 �    �� 5   
   .��5      U� $ 00:00:00X�6,   $ 
LayoutRoot��6A   $ (UIElement.Opacity)�6d   .\�5      �� $ 00:00:00��6'   $ 0Q�6:   �� 5      $ 00:00:01��6'   $
 0.95Q�6:   �� 5      $ 00:00:03��6'   $
 0.95Q�6:   5      5      �� 5   
   .��5      U� $ 00:00:00X�6,   $ imgClose��6A   $ (UIElement.Opacity)�6b   .\�5      �� $ 00:00:00��6'   $	 0.4Q�6:   �� 5      $ 00:00:00.3000000��6'   $ 1Q�6B   5      5      �� 5   
   .��5      U� $ 00:00:00X�6,   $ imgClose��6A   $ (UIElement.Opacity)�6b   .\�5      �� $ 00:00:00��6'   $ 1Q�6:   �� 5      $ 00:00:00.3000000��6'   $	 0.4Q�6B   5      5      �� 5   
   .��5       U� $ 00:00:00X�6,   $ 
LayoutRoot��6A   $ (UIElement.Opacity)�6d   .\�5!      �� $ 00:00:00��6'   $ 1Q�6:   �� 5"      $ 00:00:00.3000000��6'   $ 1Q�6B   5#      5$      �� 5%   
   -   5        .��5&      U� $ 00:00:00X�6,   $ 
LayoutRoot��6A   $ (UIElement.Opacity)�6d   .\�5'      �� $ 00:00:00��6'   $ 1Q�6:   �� 5(      $ 00:00:00.3000000��6'   $	 0.2Q�6B   5)      5*      5+       � Triggers 5,      :� 5-   
    :� RoutedEvent$# tb:TaskbarIcon.BalloonShowing��6   .[�5.      �� -   5        	 ��Name$	 FadeIn_BeginStoryboard��5.   C   #��[  6   6C   5/      :� 50   
   $ Mouse.MouseEnter��6   
 :� 
SourceName$
 imgClose��66   .[�51      �� -   5        $*	 $HighlightCloseButton_BeginStoryboard��51   Q   #��[ 6   6Q   52      :� 53   
   $ Mouse.MouseLeave��6   $
 imgClose��66   .[�54      �� -   5        $%	 FadeCloseButton_BeginStoryboard��54   L   #��[ 6   6L   55      :� 56   
   $ Mouse.MouseEnter��6   .[�57      ��  �� BeginStoryboardName$ FadeIn_BeginStoryboard��6   �� 58      -   5        $	 FadeBack_BeginStoryboard1��58      #��[ 6A   59      :� 5:   
   $# tb:TaskbarIcon.BalloonClosing��6   .[�5;      �� -   5        $	 FadeOut_BeginStoryboard��5;   D   #��[ 6   6D   5<      .��5>      �� -   5         ��Name$ border��5>   �   $��Stretch=�6   $��Stretch=�6+   $
��Auto��6G   $
��Auto��6T    �� CornerRadius$ 0,0,0,0��6c   $��3,3,3,3q�6z   $��0,0,5,5q�6�    J� Effect 5?   
   3  -System.Windows.Media.Effects.DropShadowEffect  5@         Color$ 	#FF7A7A7A��6   ��5B   
   �� 5C       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5D      �  � Color$ 	#FF4D5397��6    � Offset$ 0Q�61   � 5E      $ 	#FF060505��6   $ 1Q�61   5F      ._�5H   
   �� 
���  ��$��1q�6#   $��3q�67   ._�5I      � -	   5         �Name$ 
LayoutRoot��5I      $
��Auto��6'    � ColumnDefinitions 5J      �� 5K      $
��auto �6'   �� 5L      $
��auto �6'   �� 5M      $
��auto �6'   �� 5N      $
��auto �6'    � RowDefinitions 5P      �� 5Q      $
��auto �6$   �� 5R      $
��auto �6$   �� 5S      $
��auto �6$   .+�5U      �� -
   5         ��Name$ image��5U   �   $��0��6   $��0��6%   $��2��65   $
��Left=�6F   $��
10,10,0,26q�6a   $��72��6u   $
��Fill=�6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.792,0.486&�6�   $��72��6�   ��6�   �� *ImageSource+z�5V      V� 5W      .~�5X      ��  �� ScaleX$ 1Q�6-    �� ScaleY$ 1Q�68   �� 5Y       �� AngleX$ 0Q�6,    �� AngleY$ 0Q�67   �� 5Z       �� Angle$ 0Q�6.   T� 5[       T� X$ 0Q�61    T� Y$ 0Q�67   5\      5^      �� 5_      $��0��6   $��1��6)   $��2��69   ���	#FFF5E9E9$��5q�6d   $
��Wrap=�6o   $��32��6�   $	��Top=�6�   $��16(�6�   $
��Bold"�6�   �� 6�     � Language$  en-gb�6�   �6�   �� ! �� Path$! Title�" �� ElementName$" me��6�   6  �� 5`      -   5        $ imgClose��5`      $��0��6   $��3��6%   $��Right=�66   $��	0,10,10,0q�6R   $	��Top=�6e   $��16��6}   $��16��6�   $-��'/FlipIcon;component/Resources/Close.png��6�   $
��Fill=�6�   # J� Opacity$	# 0.4Q�6�   $ � ToolTip$$ Close Balloon��6�   6  �� 5b      -   5        % ��Name$% txtToolTipDetail_Copy��5b   �   $��1��6   $��1��6)   $��3��69   ���	#FFF5E9E9$��5q�6d   $
��Wrap=�6o   $��12(�6�   $��Normal"�6�   �� 6�   $  en-gb�6�   �6�   �� $! Detail�$" me��6�   6  �� 5d      -   5        $% txtStatusLeft��5d   
  $��2��6   $��0��6)   $��2��69   ���	#FFF5E9E9$��5q�6d   $
��Wrap=�6o   $��Bottom=�6�   $
��Left=�6�   $��12(�6�   $
��Bold"�6�   ��6�   �� $" me��$! 
StatusLeft�6
  �� 5e      -   5        $% txtStatusRight��5e     $��2��6   $��2��6)   $��2��69   ���	#FFF5E9E9$��5q�6d   $
��Wrap=�6o   $��Bottom=�6�   $��Right=�6�   $��12(�6�   $
��Bold"�6�   ��6�   �� $" me��$! StatusRight�6  5f      5g      5h      5i      