   M S B A M L   `   `   `  ����D  @SleepDown, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SleepDown	SleepDown  5   	       SleepDown.Setting   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SleepDown     5   	     � Title$  Setting��5   	   $	��300��6   $	��600��6&   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6   .+�5   
   �� 
���   �$��1q�6%   $
��Left=�69   $	��100��6T   $��
400,10,0,0q�6a   $	��Top=�6u   $	��184��6�   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $	��250��6T   $��	10,10,0,0q�6a   $	��Top=�6t   $	��370��6�   �� 5   
   -   5         ��Name$ button��5      $y�Hidden=�6!   $-��'ローカルからファイルを選択��65   $
��Left=�6M   $��
31,190,0,0q�6h   $	��Top=�6|   $	��234��6�   $��40��6�   6�   �� 5   
   -   5         ��Name$ label��5      $��アラームの音��6   $
��Left=�60   $��30��6K   $��	10,10,0,0q�6W   $	��Top=�6j   $��98��6�   �� 5   
   -   5        $ label1��5      $'��!選択中の音声ファイル：��6    $
��Left=�66   $��33��6Q   $��	10,40,0,0q�6]   $	��Top=�6p   $	��186��6�   $��18(�6�   �� 5   
   -   5        $ CurrentSoundFile��5      $
��Left=�6*   $��
186,40,0,0q�6E   $	��Top=�6Y   $��33��6q   $	��164��6}   $��18(�6�   �� 5   
   -   5         ��Name$ comboBox��5      $
��Left=�6%   $��
31,119,0,0q�6@   $	��Top=�6T   $	��234��6l   $��41��6�   .@�5      �� -   5         ��Name$ sample1��5      $!��サンプル1(シンバル)��6,   �� 5      -   5        $ sample2��5      $��サンプル2��6,   �� 5      -   5        $ sample3��5      $��サンプル3��6,   �� 5      -	   5        $ sample4��5      $��サンプル4��6,   �� 5      -
   5        $ sample5��5      $��サンプル5��6,   �� 5      -   5        $ 	LocalFile��5      $��ファイルから選択��6.   5      �� 5   
   -   5        $ button2��5      $��保存して閉じる��6"   $
��Left=�64   $��440,213,0,0q�6O   $	��Top=�6d   $	��100��6|   $��23��6�   6�   �� 5   
   -   5        $ label2��5      $/��)アラームが鳴るまでの時間(分)��6    $
��Left=�6:   $��
410,14,0,0q�6U   $	��Top=�6i   $��26��6�   $	��165��6�   �� 5   
   -   5         ��Name$ RingSoundTime��5      $��Right=�6)   $��31��6E   $��0,59,28.6,0q�6Q    �� TextWrapping$
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��155��6�   $��18(�6�   5       5!      