# AlexnetProject
This is a small project where (the pre-trained) Alexnet is implemented into a windows form app where the user can upload or use provided images that the model will try to classify.
# Motivation
This project is part of a job-search, and was requested by a potential employer as part of a job-application.
# AlexNet
AlexNet is a CNN that classifies 224x224 images based the 1000 classes it was trained on. More about AlexNet here: https://en.wikipedia.org/wiki/AlexNet.
# Bugs/errors
I've found a few problems when trying to download or clone this repo:

i) downloading as zip and unzipping seems to corrupt the 'alexnet1.onnx' file, so the solution won't build.

ii) For me, cloning the repo will be successfull, however you might get an error saying that the cloning of the 'alexnet1.onnx' file was unseccessfull. It was uploaded using "github large file storage" (it is >100MB), and different git settings might resolve this issue. 

# Framework used
The project was built/created in Visual Studio 2022 on the windows forms app template with the ML.net framework.

# How to use

1.0) (Recommended) This step requires pytorch and python. Run the RUNME.py file or the RUNMEnotebook.ipynb (Jupyter notebook) file. This will produce a file called 'alexnet1.onnx'.

1.1) Download or clone the repo. Make sure you get the 'alexnet1.onnx' file (see bugs/errors).


2.0) Build the solution (AlexNet.snl) in an IDE. It might not build successfully, but move on to the next step.

3.0) Make sure the file named 'alexnet1.onnx' is located under \bin\x86\Debug\model. Now try building it again, it should run. Tips for users of Visual Studio: you may have to change the file properites of 'labels.txt' and 'alexnet1.onnx' to "copy always". 

4.0) You can now either run the solution in an IDE or run the application file AlexNet under \bin\x86\Debug.

# Credits 
Thanks to this incredible helpful video by Jon Wood on YouTube for helping me get started: 
https://www.youtube.com/watch?v=KDxbXlwPPqk&t=92s&ab_channel=JonWood
And this helpful article by Vasil Kosturki:
https://vkontech.com/making-predictions-in-c-with-a-pre-trained-tensorflow-model-via-onnx/
