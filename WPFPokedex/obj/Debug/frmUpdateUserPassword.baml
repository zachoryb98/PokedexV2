   M S B A M L   `   `   `  ����E  AWPFPokedex, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WPFPokedex
WPFPokedex  5   	   &     WPFPokedex.frmUpdateUserPassword   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WPFPokedex     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$ Update Password��5   	    � 
ResizeMode$ NoResize=�6"   $	��300��68   $	��450��6E   ���#ed3e3e.��5	      �� ���#2e3137 �� CornerRadius$ 20��6"   $��20q�64   ._�5
      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      .+�5   
   �� -   5         ��Name$ lblCurrentPassword��5      $��0��5      $��1��5      $��Center=�5      $��Center=�5      $��Current Password: ��5      $��Center=�5      $��Right=�5      $
��10 0q�5      $��DemiBold"�5       �� 5!   
   -   5        $ lblNewPassword��5!      $��0��5"      $��2��5#      $��Center=�5$      $��Center=�5%      $��New Password: ��5&      $��Center=�5'      $��Right=�5(      $
��10 0q�5)      $��DemiBold"�5*      �� 5+   
   -   5        $ lblRetypePassword��5+      $��0��5,      $��3��5-      $��Center=�5.      $��Center=�5/      $��Retype Password: ��50      $��Center=�51      $��Right=�52      $
��10 0q�53      $��DemiBold"�54      �� 55   
   -   5         ��Name$ 	btnSubmit��55      $��0��56      $��4��57      $��Submit��58      $��Right=�59      $
��10 5q�5:      $��5q�5;      $��DemiBold"�5<      6'   G� 5=   
   -   5         G�Name$ pwdCurrentUserPassword��5=      $��1��5>      $��1��5?      $	��110��5@      $��
10 10 5 10q�5A      $��Center=�5B      $��Center=�5C      $
��Left=�5D      G� 5F   
   -   5        $ pwdNewUserPassword��5F      $��1��5G      $��2��5H      $	��110��5I      $��
10 10 5 10q�5J      $��Center=�5K      $��Center=�5L      $
��Left=�5M      G� 5O   
   -   5        $ pwdRetypeUserPassword��5O      $��1��5P      $��3��5Q      $	��110��5R      $��
10 10 5 10q�5S      $��Center=�5T      $��Center=�5U      $
��Left=�5V      5Y      5Z      5[      