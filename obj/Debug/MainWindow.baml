   M S B A M L   `   `   `  ����N  JPOE_Application_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POE_Application_WPFPOE_Application_WPF  5   	   $    POE_Application_WPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POE_Application_WPF     5   	     � WindowState$  	Maximized=�5   	    � Title$ 
MainWindow��5	   	   $	��652��6   $
��1059��6)   ���	#FF2B2B2B.��5
      � $��10,10,25,14q�6   .+�5   
   � $��
10,90,0,10q�6   .+�5      (�  (� Stretch$ Uniform=�6   $��-92,-24,0,-24q�6(   $
��Left=�6?   $
��1136��6Z   .��5      �� -   5         ��Name$ 
Background��5      $��Menu.jpg��6,   $��Uniform=�6>   $��Center=�6P   $��Center=�6m   $	��525��6�    J� OpacityMask
 �   �$	��945��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      5      �� 5      -   5         ��Name$ 	AddButton��5      $	��Add��6(   $��135,194,257,0q�66   
����������	#FF00F726$	��157��6�   $��48��6�   $	��Top=�6�   $��18(�6�    5        5      5      �� 5      -   5        $ 
ListButton��5      $
��List��6)   $��135,283,257,0q�68   $	��Top=�6O   $	��157��6g   $��48��6t   
����������	#FF00F726$��20(�6�    5        5      5      �� 5       -   5        $ DisplayButton��5       $��Display��6,   $��135,387,257,-10q�6>   $	��Top=�6W   $	��157��6o   $��48��6|   
����������	#FF00F726 J� RenderTransformOrigin$ 0.456,-0.271&�6�   $��20(�6�    5!        5"      5$      5(      �� 5)   
   -   5         ��Name$ AppTitle��5)      $�� Recipe App��6"   $��	7,-16,0,0q�68   $	��Top=�6K   $��55(�6d   $��Arial Rounded MT Bold)�6r   $
��Left=�6�   $	��411��6�   ���	#FF00F90F$
��Bold"�6�   $ 0.5,0.5&�6�   $��78��6   5*        5+      z�5-      V� 5.      .~�5/      �� �� 50      �� 51      	 �� Angle$	 -0.397Q�6&   T� 52      53      55      �� 56   
   -   5        $ 
ExitButton��56      $
��Exit��6%   $��940,-150,50,556q�64   ���	#FF00F726
�������$
��Left=�6�   $	��157��6�   $��48��6�   $��20(�6�    57        58      5:      5=      5@      