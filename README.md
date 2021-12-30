# AlexnetProject
This is a small project where Alexnet is implemented into a windows form app where the user can upload or use provided images that the model will try to classify.
# Motivation
This project is part of a job-search, and was requested by a potential employer as part of a job-application.
# AlexNet
AlexNet is a CNN that classifies 224x224 images based the 1000 classes it was trained on. More about AlexNet here: https://en.wikipedia.org/wiki/AlexNet.
# Build Status
There a no known bugs or errors. 
# Framework used
The project is built in Visual Studio 2022 on the windows forms app template.
# How to use
(optional ) This step requires pytorch and python. Run the RUNME.py file or the RUNMEnotebook.ipynb (Jupyter notebook) file. This will produce a file called 'alexnet1.onnx'. Take 'alexnet1.onnx' and put it in the model folder under [\AlexnetSmall\bin\x86\Debug\model]. Proceed to step 2.

1) Make sure the file named 'alexnet1.onnx' is located under \AlexNetsamll\bin\x86\Debug\model. Tips for users of Visual Studio: you may have to change the file properites of 'labels.txt' and 'alexnet1.onnx' to "copy always". 

2) To run the program run the AlexNet (application file) in AlexNet\bin\x86\Debug or by running the project/solution file AlexNet.snl in \AlexnetSmall in an IDE
# Credits 
Thanks to this incredible helpful video by Jon Wood on YouTube for helping me get started: 
https://www.youtube.com/watch?v=KDxbXlwPPqk&t=92s&ab_channel=JonWood
And this helpful article by Vasil Kosturki:
https://vkontech.com/making-predictions-in-c-with-a-pre-trained-tensorflow-model-via-onnx/
