   M S B A M L   `   `   `  ����D  @BusTicket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BusTicket	BusTicket  5   	       BusTicket.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BusTicket     5   	     � Title$  
Aplicacion��5   	   $	��350��6   $	��525��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��16* �6   �� 5      $	��25* �6   �� 5      $
��278* �6   .+�5   
   �� $
��Left=�6   $��	10,10,0,0q�6/   $
��Wrap=�6B   $��TICKET PARA VIAJES��6V   $	��507��6p   $��18(�6|   $
��Bold"�6�   $��63��6�   $	��Top=�6�   $��3��6�   �� 5   
   $
��Left=�6   $��
10,19,0,10q�60   $	��507��6D   $��2��6P   .@�5      �� $��TabItem��6   .��5      �� .+�5      �� $��Origen��6   6/   �� 5      -   5         ��Name$ Origen��5      61   �� 5      $��Destino��6   60   �� 5      -   5        $ Destino��5      62   �� 5      $��Fecha��6   6.   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ DiaViaje��5   !   65   �� 5      -   5        .��5   2   Buscar6:   �� 5      -   5         ��Name$ LVResultados��5      $	��200��65   6D   5      5      �� 5      $��TabItem��6   .��5      ��  �� Orientation$ 
Horizontal=�6   ���	#FFE5E5E5.+�5       �� 6   �� 5!      6   �� 5"      6!   5$      5%      5&      5'      5(      