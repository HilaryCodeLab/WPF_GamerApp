   M S B A M L   `   `   `  ����O  KWPF-Gamers-Dashboard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WPF_Gamers_DashboardWPF_Gamers_Dashboard  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   %    WPF_Gamers_Dashboard.searchPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WPF_Gamers_Dashboard     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   R NMahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5	      -   5        $	��800��5   
   $	��480��6   $	��800��5      $	��480��6&     � Title$  
searchPage��5   	   .��5      � .+�5   
   �� -   5         ��Name$ 	btnReturn��5      $��Return��6$   $
��Left=�65   $��
662,74,0,0q�6P   $	��Top=�6d   $��74��6|   6�   �� 5   
   -   5        $ btnAdd��5      $	��Add��6!   $
��Left=�6/   $��660,204,0,0q�6J   $	��Top=�6_   $��76��6w    J� RenderTransformOrigin$ 0.625,2.204&�6�   �� 5   
   -   5         ��Name$ lstvCustomers��5      $
��Left=�5      $	��326��5      $��	10,38,0,0q�6    $	��Top=�5      $	��608��6+    �� View 5      �� 5      .P�5      ��  �� Width$	 150��5      $��Company Name��5       �� DisplayMemberBinding 5      �� *companyName+5      �� 5       $	 106��5!      $��Phone��5#       5"      �� *phoneNumber+5#      �� 5%      $	 106��5&      $��Email��5(       5'      �� *email+5(      �� 5+      $	 244��5,      $��Address��5.       5-      �� *	address+5.      50      52      �� 53   
   -   5        $ 	btnDelete��53      $��Delete��6$   $
��Left=�65   $��660,277,0,0q�6P   $	��Top=�6e   $��76��6}   6�   �� 55   
   $��Bottom=�6   
����� �$��	0,412,0,0q�6B   ��56      �� 57      .R�58      �  � ColumnDefinitions 59      �� 5:      $	��500 �6/   �� 5;      $
��Auto �6/   �� 5<      $��* �6/   5?      5@      .@�5B      �� .��5C      �� -   5         ��Name$ FileNameLabel��5C      $��Ready��64   5D      �� 5E      $��1��6   �� 5F      $��2��6   $��Right=�6,   .��5G      �� -   5        $��RecordNumberLabel��5G      $��Record��65   5H      5I      �� 5J   
   -   5        $ btn_Save��5J      $
��Save��6#   $
��Left=�62   $��660,136,0,0q�6M   $	��Top=�6b   $��74��6z   $ 0.216,0.463&�6�   6�   5N      5O      