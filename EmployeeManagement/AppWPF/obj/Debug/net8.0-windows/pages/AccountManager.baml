   M S B A M L   `   `   `  ����A  =AppWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:AppWPF.pagesAppWPF.pages  5   	   !    AppWPF.pages.AccountManager   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:AppWPF.pages     5   	   -   5        .��5
      �   � RowDefinitions  5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��10 15 10 10q�6;   .+�5      �� $
��Role��6   �� 5      -   5         ��Name$ txbSearchRole��5      $��80��6.   6]   �� 5      $��	Full Name��6   $��10 0 0 0q�6(   �� 5      -   5         ��Name$ txbSearchName��5      $	��300��6-   69   �� 5      $��	Search ID��6   $��	100 0 0 0q�6(   �� 5      -   5        $ txbSearchID��5      $	��300��6+   $��	10 0 10 0q�67   �� 5      -   5         ��Name$ 	btnSearch��5      $��Search��6(   $��60��6:   6E   �� 5      -   5        $ 	btnClearn��5      $��Clearn��6(   $��60��6:   $��70 0 0 0q�6E   6W   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ loadData��5         AutoGenerateColumns$ False��6%   $��1��6A      CanUserAddRows$ False��6r      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 	Member ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *
MemberId+6U     5      $	 	Full Name��6%   $
 * 6U    68   �� *
FullName+6U     5      $	 Email Address��6%   $
 * 6]    6<   �� *EmailAddress+6]     5       $
	 Role��6%   $
 * 6X    63   �� *MemberRoleString+6X   4  .System.Windows.Controls.DataGridTemplateColumn  5!      $	 Action��6)   $
 50 69      CellTemplate 5"      �� 5#      .R�5$      �� $ 
btnDeleted��6%   -   5        .��5%   "   �� $@��:pack://application:,,,/AppWPF;component/Images/deleted.jpg��6(   $��16��6l   $��16��6w   5&      5'      5)      5+      �� 5,   
   $ Vertical=�6   $��2��6,   $��0 20 0 0q�69   .+�5-      �� $��
ID Account��6   $��10 0 0 0q�6)   �� 5.      -	   5        $ txbID��5.      $��	15 0 30 0q�6%   $��30��68   �� 5/      $��Pass Account��6   $��	10 10 0 0q�6+   G� 50      -
   5         G�Name$ txbPass��50      $��30��6+   $��	15 0 30 0q�67   �� 51      $��Full Name Account��6   $��	10 10 0 0q�60   �� 52      -   5        $ txbName��52      $��30��6'   $��	15 0 30 0q�63   �� 53      $��Email Account��6   $��	10 10 0 0q�6,   �� 54      -   5        $ txbEmail��54      $��30��6(   $��	15 0 30 0q�64   �� 55      $��Role Account��6   $��	10 10 0 0q�6+   �� 56      -   5        $ cbnRole��56      $��30��6(   $��	15 0 30 0q�64   6G   57      �� 58   
   $ 
Horizontal=�6   $��3��6.   $��
10 0 10 10q�6;   .+�59      �� -   5        $ 	btnUpdate��59      $��Update��6(   $	��100��6Q   $��	300 0 0 0q�6]   
���  ��6p   �� 5:      -   5        $ btnAdd��5:      $	��Add��6%   $	��100��6H   $��	100 0 0 0q�6T   
���  ��6g   �� 5;      -   5        $ 
btnRefresh��5;      $��Refresh��6)   $	��100��6T   $��	100 0 0 0q�6`   
���  ��6s   5<      5=      5>      