   M S B A M L   `   `   `  ����F  BWPFDesigner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:WPFDesigner;assembly=WPFDesignerWPFDesigner  5      J FWebModelingTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WebModelingToolWebModelingTool 6Q   -   'WebModelingTool.UserControlUIDefinition   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      FWPFDesigner.clr-namespace:WPFDesigner;assembly=WPFDesigner     5      /localclr-namespace:WebModelingTool     6Q   .��5
      �   � ColumnDefinitions  5   
   �� 5      $	��300 �6   �� 5      $��* �6   �� 5      $	��200 �6   .+�5   
   � -   5         �Name$ UIPropertyGrid��5      $��2��6'   
�������67   �� 5   
   $��2��6   $
��Left=�6'   $��4��6B   ���#BFDBFF6L   �� 5   
   -   5         ��Name$ HtmlCodeRichTextBox��5      $��0��63   $��0q�6C   $��0 0 4 0q�6W   �� 5   
   $��0��6   $��Right=�6$   $��4��6@   ���#BFDBFF6J   � 5   
   $��1��6    � RowDefinitions 5      �� 5      $��* �6    $��80��6+   �� 5      $
��auto �6    �� 5      $	��150 �6    $��50��6-   .+�5      � -   5        $ _grid2��5      $��0��6#     5      �� 5      �� 5      $
��Auto �6'   �� 5      $
��Auto �6'   .+�5       �� -   5         ��Name$ 
_htmlPanel��5       $��0��63   
�������.��5!      � -   5        $ DNDGrid��5!      .+�5"         WPFDesigner.Designer  5#      5$      �� 5%      -   5         ��Name$ 	_splitter��5%      $��1��62   $��4��6B   $��Stretch=�6L    �� ResizeBehavior$ PreviousAndNext=�6h   ���#BFDBFF$y�	Collapsed=�6�   (  "System.Windows.Controls.WebBrowser  5&      -   5          Name$ _webBrowser��5&      $��1��62   $y�	Collapsed=�6B   5'      �� 5(      $��1��6   $��Stretch=�6(   $��4��6F   ���#BFDBFF6Q     5)      -   5        $ 
htmlViewer��5)      $��2��6-   5*      5,      5-      