   M S B A M L   `   `   `  ����F  BTestTakMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TestTakMVVMTestTakMVVM  5   	       TestTakMVVM.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TestTakMVVM     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��425* �6   �� 5      $
��367* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ parametrsGrid��5         AutoGenerateColumns . $
��auto��6�   $
��auto��6�   $��0,0,107,268q�6�      CanUserAddRows .    CanUserDeleteRows . ��6*   �� *	Parametrs+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6q   �� *SelectedParametr+   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      	   CellTemplate	 5      �� 5      .R�5      �� -   5        .��5   >   Список6F   5      5      5      �� 5   
   -   5        $��
30,0,0,149q�5      
 J� RenderTransformOrigin$	
 1,1&�6%   $
��Left=�6A   $��Bottom=�6]   $
��20px��6x   $��55��6�   .��6�   up6�   �� 5   
   -   5        $��135,0,0,149q�5      $	
 1,1&�6&   $
��Left=�6B   $��Bottom=�6^   $
��20px��6y   $��70��6�   .��6�   down6�   �� 5   
   $
��20px��60   $
��55px��6>   $��
30,0,0,214q�6L   $
 
-1.867,0.7&�6`   $
��Left=�6�   $��Bottom=�6�   ��6   �� *
AddCommand+.��6�   add6�   �� 5    
   $��135,0,0,214q�6a   $	
 1,1&�6v   $
��Left=�6�   $��Bottom=�6�   $
��20px��6�   $
��70px��6�   ��6   �� *RemoveCommand+��63   �� *SelectedParametr+.��6�   remove6�   �� 5!   
   -   5        $��
30,0,0,184q�5!   1   $	
 1,1&�6E   $
��Left=�6a   $��Bottom=�6}   $
��20px��6�   $��55��6�   ��6   �� *SaveCommand+.��6�   save6�   �� 5"   
   $��135,0,0,184q�61   $	
 1,1&�6F   $
��Left=�6b   $��Bottom=�6~   $
��20px��6�   $��70��6�   ��6   �� *OpenCommand+.��6�   load6�   5#      5$      