### [Install dotnet](https://dotnet.microsoft.com/learn/ml-dotnet/get-started-tutorial/install)
### Usage

    Usage:
    mlnet auto-train [options]

    Options:
    -T, --task, --mltask, --ml-task <ML-TASK>            Type of ML task to perform. Current supported tasks: regression, binary-classification, multiclass-classification.
    -d, --dataset <DATASET>                              File path to either a single dataset or a training dataset for train/test split approaches.
    -v, --validation-dataset <VALIDATION-DATASET>        File path for the validation dataset in train/validation/test split approaches.
    -t, --test-dataset <TEST-DATASET>                    File path for the test dataset in train/test approaches.
    -n, --label-column-name <LABEL-COLUMN-NAME>          Name of the label (target) column to predict.
    -i, --label-column-index <LABEL-COLUMN-INDEX>        Index of the label (target) column to predict.
    -H, --has-header <HAS-HEADER>                        Specify true/false depending if the dataset file(s) have a header row.
    -x, --max-exploration-time <MAX-EXPLORATION-TIME>    Maximum time in seconds for exploring models with best configuration.
    -c, --cache <CACHE>                                  Specify on/off/auto if you want cache to be turned on, off or auto determined.
    -I, --ignore-columns <IGNORE-COLUMNS>                Specify the columns that needs to be ignored in the given dataset.
    -V, --verbosity <VERBOSITY>                          Output verbosity choices: q[uiet], m[inimal] (by default) and diag[nostic].
    -N, --name <NAME>                                    Name for the output project or solution to create. 
    -o, --output-path <OUTPUT-PATH>                      Location folder to place the generated output. The default is the current directory.

### Binary Classify
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
# (optional)
dotnet restore
# change Program.cs in consumeModeApp
dotnet run
```

### 

```bash
head -n 10 taxi-fare-train.csv

vendor_id,rate_code,passenger_count,trip_time_in_secs,trip_distance,payment_type,fare_amount
CMT,1,1,1271,3.8,CRD,17.5
CMT,1,1,474,1.5,CRD,8


mlnet auto-train 
--task binary-classification
--dataset "taxi-fare-train.csv" 
--label-column-name "fare_amount" 
--max-exploration-time 30
```