   M S B A M L   `   `   `  ����N  JPOE_Application_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POE_Application_WPFPOE_Application_WPF  5   	   $    POE_Application_WPF.RecipeList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POE_Application_WPF     5   	     � WindowState$  	Maximized=�5   	   ���	#FF2B2B2B � Title$ 
RecipeList��5
   	   $	��628��6   $
��1291��6)   .��5      � $��10,10,10,-6q�6   .+�5   
   � -   5         �Name$ MainGrid��5      $��85,104,141,80q�6!   .+�5      �� -   5         ��Name$ TextBoxRectangle��5      $
��Left=�62   $��38��6M   $��	64,96,0,0q�6Y   
���   �$	��Top=�6{   $
��1173��6�   
������� �� RadiusX$	 5.5��6�    �� RadiusY$	 5.5��6�   �� 5      -   5         ��Name$ List_Button��5      $��List all��6*   $
��Left=�6=   $��1085,10,0,0q�6X   $	��Top=�6m   $��34��6�   $	��150��6�    J� RenderTransformOrigin$ 0.714,1.689&�6�   ���	#FF00F726
�������$��18(�6  $
��Bold"�6   J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5      -   5        $ Back_Button��5      $��	Main Menu��6*   $
��Left=�6>   $��1085,-64,0,0q�6Y   $	��Top=�6o   $��40��6�   $	��153��6�   $��18(�6�   ���	#FF00F726
�������$
��Bold"�6�    5        5      5      �� 5      -   5        	 ��Name$	 RecipeListView��5      $��64,131,53,10q�6/   
�������
 � 	Resources
 5       �� 
TargetType �� Property �� Value��%w   '��       �� 5      " ��6   .�5      ��  � ��$ 16(�65   �� 5       � ��$	 8,0q�63   5      5       �� View 5       �� 5!      .P�5"      �� $��
Recipe No.��6)    �� Width$
 Auto��6=    �� DisplayMemberBinding 6J   �� *Count+�� 5#      $��Recipe Name��6)   $
 Auto��6>    6K   �� *
RecipeName+�� 5$      $��Total Calories��6)   $
 Auto��6A    6N   �� *
Calories+5%      5'      �� 5(      -   5        $ SearchButton��5(      $��Search��6+   $
��Left=�6<   $��1142,96,0,0q�6W   $	��Top=�6l   $��35��6�   $��94��6�   $��16(�6�   $
��Bold"�6�   $ 0.463,0.418&�6�   �� 5)      -   5         ��Name$ RecipeNameTextBox��5)      $
��Left=�61   $��
64,103,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��204��6�   $��16(�6�   $��Enter Recipe to display��6�   
�������6�   5*      � 5,   
   -   5        $ BackgroundGrid��5,      $��
10,34,0,10q�6'   .+�5-      �� -	   5         ��Name$ RecipeListLable��5-      $��Recipes Currently Added:��6-   $
��Left=�6P   $��
135,10,0,0q�6k   $	��Top=�6�   ���	#FF00F90F$��40(�6�   $
��Bold"�6�   $	��535��6�   $��84��6�    5.        5/      51      52      53      54      