   M S B A M L   `   `   `  ����O  KFlipIcon, Version=0.2.1.0, Culture=neutral, PublicKeyToken=6e63ad01286bf8263clr-namespace:FlipIcon.WindowsFlipIcon.Windows  5   	       FlipIcon.Windows.AboutBox   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,wclr-namespace:FlipIcon.Windows     5   	   -   5          >�Name$  aboutBox��5      .��5	      � -   5        $��tableLayoutPanel��5	       � ColumnDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��logoPictureBox��5      $��0��6&   $��0��66   $��4��6C   $0��*/FlipIcon;component/Resources/FlipIcon.png��6T   $	��Top=�6�   $��64��6�   $��64��6�   �� 5   
   -   5        $��TextBlockDescription��5      $��1��60   $��0��6@   $��2��6M   $��6,0,3,0q�6a   $
��Wrap=�6r   ��6�   �� *ProductDescription+�� 5   
   -   5        $��TextBlockCopyright��5      $��1��6.   $��3��6>   $��2��6K   $��6,0,3,0q�6_   $
��Wrap=�6p   ��6�   �� *ProductCopyright+�� 5   
   -   5        $��TextBlockCompanyName��5      $��1��60   $��2��6@   $��2��6M   $��6,0,3,0q�6a   $
��Wrap=�6r   �� 5      $�
Written by��6    �� 5      �6   �� *CompanyName+5      �� 5   
   -   5        $��textBoxVersionHistory��5      $��1��6/   $��4��6?   $��2��6L   $��6,13,3,3q�6`   $��10q�6r    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn .  �� 
IsReadOnly . $��Disabled=�6�   $��Visible=�6�   ��6$  �� *VersionHistory+y�6D  �� *VersionHistoryVisibility+�� 5   
   -   5        $ ��AdditionalContentPresenter��5      $��0��6=   $��4��6M   $��3��6Z   ��6n   �� *AdditionalContent+y�6�   �� *AdditionalContentVisiblity+�� 5!   
   $��0��6   $��5��6%   $��2��62   $��Right=�6F    �� Orientation$ 
Horizontal=�6b   .+�5"      �� -	   5        $��textBlockTitle��5"      $��0��6.   $��5��6>   $��Center=�6K   $��Center=�6h   $��24(�6�   $��10,0,0,0q�6�   �� 5#      �6   �� *ProductTitle+ �� 5$      �6   �� *	Version+ �� 5%      $�by��6    J� Effect 5&      3  -System.Windows.Media.Effects.DropShadowEffect  5'         Color$ 	#FF25ADC3��6'   	   
BlurRadius$	 10Q�69   
   	Direction$	
 314Q�6I   5)      �� 5*      -
   5         ��Name$ pictureBox1��5*      $��50��6)   $=��7/FlipIcon;component/Resources/Mark Vinten Signature.png��65   $��0,10,0,0q�6v    5+        5,      $ 	#FF25ADC3��6'   $	 10Q�69   $	
 314Q�6I   5.      5/      50      51      