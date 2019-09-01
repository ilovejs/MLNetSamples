### [Install dotnet](https://dotnet.microsoft.com/learn/ml-dotnet/get-started-tutorial/install)

```bash
dotnet tool install -g mlnet
# Folder for inference app
mkdir myMLApp
cd myMLApp
dotnet new console -o consumeModelApp
# train
mlnet auto-train --task binary-classification --dataset "wikipedia-detox-250-line-data.tsv" --label-column-name "Sentiment" --max-exploration-time 10
# Construct inference console
cd consumeModelApp
dotnet add reference ../SampleBinaryClassification/SampleBinaryClassification.Model/
dotnet add package Microsoft.ML --version 1.3.1
# change Program.cs in consumeModeApp
dotnet run
```