   M S B A M L   `   `   `  ����E  AWPFPokedex, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WPFPokedex
WPFPokedex  5   	   $    WPFPokedex.frmCollectedPokemon   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WPFPokedex     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5       � Title$ Collected Pokemon��5   	   $	��800��6#   $
��1224��60    � 
ResizeMode$ NoResize=�6=   ���#ed3e3e.��5	      � $��4��6    � ColumnDefinitions 5
   
   �� 5      $	��200 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��0 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   � $��1��6   $��1��6    5      �� 5      $
��603* �6#   �� 5      $
��415* �6#   5      � 5   
   $��1��6   $��1��6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dgMyPokemonList��5      $��	0 0 0 100q�60      SelectionMode$ Single=�6C      
IsReadOnly . 6�   5      �� 5   
   $��2��6   $��2��6!   ���#2e3137.@�5      �� .��5      �� -   5         ��Name$ lblStatusMessage��5      $��DemiBold"�5       $��50 0 0 0q�5!      
�������.��5"   +   Login Success5$      5%      5&      � 5(   
   ���#2e3137$��1��6$   .+�5)      �� $��1��6   .+�5*      �� -   5        	 ��Name$	 btnHome��5*      $��10q�6*   $��40��66   $��18(�6B   $
��Bold"�6P   ���#ffcb05���#2e3137.��5+      � $	��150��6   .+�5,      �� $��Right=�6$   $
��Home��6@   $��0,0,50,0q�6L   5-      
 � 	Resources
 5.       �� 
TargetType �� Property �� Value��%_   '��       �� 5/      " ��6    .�50      ��  �@��CornerRadius$ 15��6=   51      52      53      �� 54      -   5        $	 btnPokedeList��54      $��10q�60   $��40��6<   $��18(�6H   $
��Bold"�6V   ���#ffcb05���#2e3137.��55      � $	��150��6   .+�56      �� $��Center=�6$   $��PokéDex��6A   57      
 58      ��%_   '��       �� 59      " ��6    .�5:      ��  �@��CornerRadius$ 15��6=   5;      5<      5=      �� 5>      -   5        $	 btnStatsCompare��5>      $��10q�62   $��40��6>   $��18(�6J   $
��Bold"�6X   ���#ffcb05���#2e3137.��5?      � $	��150��6   .+�5@      �� $��Center=�6$   $��Stats Compare��6A   5A      
 5B      ��%_   '��       �� 5C      " ��6    .�5D      ��  �@��CornerRadius$ 15��6=   5E      5F      5G      �� 5H      -   5        $	 btnLocation��5H      $��10q�6.   $��40��6:   $��18(�6F   $
��Bold"�6T   ���#ffcb05���#2e3137.��5I      � $	��150��6   .+�5J      �� $��Center=�6$   $��Location��6A   5K      
 5L      ��%_   '��       �� 5M      " ��6    .�5N      ��  �@��CornerRadius$ 15��6=   5O      5P      5Q      �� 5R      -   5        $	 btnAdmin��5R      $��10q�6+   $��40��67   $��18(�6C   $
��Bold"�6Q   ���#ffcb05���#2e3137.��5S      � $	��150��6   .+�5T      �� $��Right=�6$   $��Admin��6@   $��0,0,38,0q�6M   5U      
 5V      ��%_   '��       �� 5W      " ��6    .�5X      ��  �@��CornerRadius$ 15��6=   5Y      5Z      5[      �� 5\      -	   5        $	 	btnLogout��5\      $��10q�6,   $��40��68   $��18(�6D   $
��Bold"�6R   ���#ffcb05���#2e3137.��5]      � $	��150��6   .+�5^      �� $��Right=�6$   $��Logout��6@   $��0,0,38,0q�6N   5_      
 5`      ��%_   '��       �� 5a      " ��6    .�5b      ��  �@��CornerRadius$ 15��6=   5c      5d      5e      5f      �� 5g      $��Images\Pokedex_logo.png��6   $��10q�65    5h      �� 5i      $	��100 �6    �� 5j      $��* �6    5l      � 5m   
   $��1��6   $��1��6    5n      �� 5o      $��50 �6    �� 5p      $��* �6     5s      �� 5t      $��1* �6#   �� 5u      $��112.59 �6#   �� 5v      $��487.41 �6#   �� 5w      $��* �6#   .+�5y      �� -
   5        $	 btnBack��5y      $
��Back��6&   $
��Left=�65   $��
16,619,0,0q�6P   $��1��6d   $	��Top=�6q   $	��111��6�   $��56��6�   6�   �� 5z      -   5        $	 
btnShinies��5z      $��Shinies��6)   $
��Left=�6;   $��142,619,0,0q�6V   $��1��6k   $	��Top=�6x   $	��111��6�   $��56��6�   $��2��6�    J� RenderTransformOrigin$ 0.613,0.429&�6�   �� 5{      -   5        $	 btnRegionalVariants��5{      $��Regional Variant��62   $
��Left=�6M   $��
72,619,0,0q�6h   $��1��6|   $	��Top=�6�   $	��111��6�   $��56��6�   $��2��6�   6�   �� 5|      -   5        $	 btnAlternate��5|      $��
Alternates��6+   $
��Left=�6@   $��197,619,0,0q�6[   $��1��6p   $	��Top=�6}   $	��111��6�   $��56��6�   $��2��6�   6�   �� 5}      -   5        $	 btnAllPokemon��5}      $��All Pokemon��6,   $
��Left=�6B   $��447,619,0,0q�6]   $��1��6r   $	��Top=�6   $	��111��6�   $��56��6�   $��2��6�   $��2��6�   6�   �� 5~      -   5        $	 btnNormalPokemon��5~      $��Normal Pokemon��6/   $
��Left=�6H   $��322,619,0,0q�6c   $��1��6x   $	��Top=�6�   $	��111��6�   $��56��6�   $��2��6�   6�   �� 5      -   5        $	 btnRemovePokemon��5      $��Remove Pokemon��6/   $
��Left=�6H   $��
85,619,0,0q�6c   $��1��6w   $	��Top=�6�   $	��111��6�   $��56��6�   $��3��6�   6�   �� 5�      -   5        $	 btnAddPokemon��5�      $��Add Pokemon��6,   $
��Left=�6B   $��
85,619,0,0q�6]   $��1��6q   $	��Top=�6~   $	��111��6�   $��56��6�   $��3��6�   6�   �� 5�      -   5        $	 btnMegas��5�      $��Megas��6'   $
��Left=�67   $��
60,619,0,0q�6R   $��1��6f   $	��Top=�6s   $	��111��6�   $��56��6�   $��1��6�   $��2��6�   5�      5�      5�      