   M S B A M L   `   `   `  ����  	PPEProjet     PPEProjet.fenetreOperateur   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   $	��350��6@   $	��525��6M   .��5      � ���#F5F5F5  � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5	   
   �� 5
      $
��344* �6   �� 5      $
��181* �6   .+�5   
   �� $��0��6   $��20,20,20,20q�6"   $��2��67   .+�5      �� -   5         ��Name$ textBlockLabelOp��5      $��Bienvenue Opérateur��6.   $��24(�6L   $
��Bold"�6Z   ���#3333336l   5      � 5   
   $��1��6   ���#FFFFFF$��20,20,20,20q�61   $��2��6F     5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6&   $��10q�6?   .+�5      �� $��Liste des ouvrages��6   $
��Bold"�65   $��16(�6G   ���#3333336U   �� 5      -   5         ��Name$ 
btn_ouvrir��5      $��Ouvrir��6-   $��10,0,0,0q�6>   ���#4CAF50
�������$
��10,5q�6x   $��0q�6�   6�   5      �� 5      -   5         ��Name$ listOuvrage��5      $��1��6,   $��10q�69   $��1q�6E   ���#E0E0E0 �� View 5      �� 5      .P�5       �� $
��ISBN��6)    �� DisplayMemberBinding 67   �� *Id+�� 5!      $��Titre��6)    68   �� *Titre+�� 5"      $��Editeur��6)    6:   �� *	Editeur+5#      5%      5&      5'      5(      