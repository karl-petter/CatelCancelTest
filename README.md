CatelCancelTest
===============

Small Catel project to investigate possible issue with a ViewModel decorated with the [Model] attribute.

Think I might have found a bug or not made the correct modelling because when I cancel a property in my model gets changed. Let me explain and provide with a simple test.

A have a Machine model with a Running property. In my MainWindow I have a TextBlock that shows the state of one instance of Machine. There is also a button to bring up a simple control to start and stop the machine. The ViewModel for the MainWindowView has a CurrentMachine property decorated with the Model attribute, and control is implemented in the StartStopView and through the StartStopViewModel which has the ControlledMachine property(that also is decorated with the Model attribute). When the user press the button in the MainWindow the command bind to it creates and instance of StartStopViewModel giving it the instance of the CurrentMachine and then calls ShowDialog.

If the user clicks either Start or Stop button they set Running to true or false respectively and it works as expected. What does not work is as expected is if the user clicks Cancel in the dialog. Then Running is set to false though not through calling the set method for the Running property(setting a breakpoint there reveals that). Though what seems to happen in the background is that when pressing Cancel the ControlledMachine value is assigned to a newly created instance of Machine! I see this if I assign a default value to Running in the Machine constructor and put a breakpoint there:
```
CancelTest.exe!Machine.Machine() Line 14	C#
[Native to Managed Transition]
Catel.Core.dll!Catel.IoC.TypeFactory.TryCreateToConstruct(System.Type typeToConstruct, System.Reflection.ConstructorInfo constructor, object[] parameters, bool checkConstructor, bool hasMoreConstructorsLeft) Line 552 + 0xd bytes	C#
Catel.Core.dll!Catel.IoC.TypeFactory.CreateInstanceWithSpecifiedParameters(System.Type typeToConstruct, object[] parameters, bool autoCompleteDependencies, bool preventCircularDependencies) Line 327 + 0x81 bytes	C#
Catel.Core.dll!Catel.IoC.TypeFactory.CreateInstance(System.Type typeToConstruct) Line 129 + 0x12 bytes	C#
Catel.Core.dll!Catel.Runtime.Serialization.SerializerBase<Catel.Runtime.Serialization.Xml.XmlSerializationContextInfo>.GetContext(System.Type modelType, System.IO.Stream stream, Catel.Runtime.Serialization.SerializationContextMode contextMode) Line 264 + 0x14 bytes	C#
Catel.Core.dll!Catel.Runtime.Serialization.SerializerBase<Catel.Runtime.Serialization.Xml.XmlSerializationContextInfo>.DeserializeMembers(System.Type modelType, System.IO.Stream stream) Line 209 + 0x11 bytes	C#
Catel.Core.dll!Catel.Data.ModelBase.BackupData.RestoreBackup() Line 117 + 0x31 bytes	C#
Catel.Core.dll!Catel.Data.ModelBase.System.ComponentModel.IEditableObject.CancelEdit() Line 297	C#
Catel.Core.dll!Catel.Data.EditableObjectHelper.CancelEditObject(object obj) Line 77	C#
Catel.MVVM.dll!Catel.MVVM.ViewModelBase.UninitializeModel(string modelProperty, object model, Catel.MVVM.ModelCleanUpMode modelCleanUpMode) Line 1224 + 0x9 bytes	C#
Catel.MVVM.dll!Catel.MVVM.ViewModelBase.CancelViewModel() Line 1408 + 0x8f bytes	C#
```
I have not yet started to dig into the Catel code to see what is actually happening within Catel but to me this seems not to be the expected behaviour, correct?

I have tested this both with 3.9.0 and the latest 4.0.0(unstable0456). It behaves the same.
