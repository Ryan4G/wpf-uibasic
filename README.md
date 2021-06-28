# WPF-UIBasic

## 介绍
简单WPF UI入门知识代码。

## WPF UI布局

> StackPanel
> WrapPanel
> DockPanel
> Grid / RowDefinitions / ColumnDefinitions
> UniformGrid
> Canvas

### 意义不明控件

> Border
> UniformGrid


## WPF UI样式

> 通过Windows.Resources 新建 Style 进行样式预制，通过 Setter 进行设置具体属性值
> Style 之间可以存在继承关系

### 样式触发器

> 在Style 内可使用 Style.Triggers，定义不同的触发器用于改变样式
> Trigger 简单触发器，直接定义触发的行为和数值后 使用Setter
> MultiTrigger 多条件触发器，分为Condition 定义不同情况的行为和数值，再单独定义 Setter
> EventTrigger 事件触发器，需嵌套 Action，里面再套开始故事板 BeginStoryboard ，故事板 StoryBoard，最后实现动画

## WPF UI控件模板

> 控件可通过 Template 属性获取静态资源内的模板进行绑定
> 在Windows.Resources 内可新建 ControlTemplate 定义控件的样式、行为

## WPF UI数据模板

> 常用控件类型分为:
>> ItemControl 
>>> DataGrid
>>> ListBox \ ComboBox \ TreeView ...

>> ContentControl
>>> UserControl

> 其中对应模板类型为：
>> DataGrid - CellTemplate
>> ListBox \ ComboBox ... - ItemTemplate
>> ContentControl - ContentTemplate

> DataGrid 可以在声明标签内添加 DataGridTemplateColumn ，再添加 CellTemplate ,添加 DataTemplate 进行自定义控件构建
> ItemContro类的控件 可在Windows.Resources 内构建 DataTemplate，再由对应控件通过ItemTemplate 绑定模板
> ItemControl可直接作为一个控件进行使用，类似用户控件，直接声明ItemControl 并在内部构建ItemsPanel 和 ItemTemplate

## WPF UI数据绑定

> 可绑定其他控件的值，使用Binding 可选择 ElementName 进行绑定
> 可通过静态资源声明，使用Binding 可选择Source 填充静态资源
> 可通过数据上下文进行绑定，需在后台代码数据赋予DataContext，还支持FallbackValue的配置
> 要实现控件动态变更数据，还需要DataContent 传入的类实现 INotifyChanged 的接口，在公开属性set 的时候手动触发事件
> 可通过第三方Nuget包实现控件动态变更数据，引入 MvvmLight 包，需要传入的类继承自ViewModelBase 类，类似的需要在公开属性set 的时候手动触发事件 RaisePropertyChanged() 方法

### WPF UI的MVVM模式

> 需要引入MvvmLight 包，主要使用到了绑定的数值功能，绑定Command 命令功能
> 类似WinForm 的窗口调用及值传递，但数据列表的动态绑定刷新，需使用ObservableCollection 定义集合，并在DataGrid 中绑定 ItemSource







