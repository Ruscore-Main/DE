   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.TourList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  Список туров��5   	   $	��450��6   $	��690��6+   $	��690��6:   .��5
      � .+�5   
   �� $4��.Введите текст для поиска:��6   $
��Left=�64   $��
232,12,0,0q�6O   $	��Top=�6c   �� 5   
   $��Выберите тип:��6   $
��Left=�6(   $��
312,41,0,0q�6C   $	��Top=�6W   �� 5   
   -   5        $��textBoxSearch��5      
���   �$
��Left=�6;   $��23��6V   $��
426,17,0,0q�6b    �� TextWrapping$
 Wrap=�6v   $�� ��6�   $	��Top=�6�   $	��224��6�   �� 5   
   -   5        $��comboBoxSearch��5       �� SelectedIndex$ 0��6\   $
��Left=�6n   $��
426,47,0,0q�6�   $	��Top=�6�   $	��224��6�   $��22��6�   $��22��6�   ��5      -  'System.Windows.Data.CompositeCollection  5      �� 5      .��6"   Все типы6,   �� 5      5      5      �� 5   
   -   5        $��checkBoxSearch��5      $0��*Только актуальные туры��6m   $
��Left=�6�   $��
426,74,0,0q�6�   $	��Top=�6�   �� 5   
   $��0,94,0.2,10q�6   $��Hidden=�6,   $
��Auto=�6S   .��5      � -   5        $��	wrapPanel��5      $
��Left=�6)   $��10,0,0,0q�6D   $	��Top=�6V   $	��680��6n   5      5      5      