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

# train on small set 250 samples
wc -l wikipedia-detox-250-line-data.tsv

mlnet auto-train \
--task binary-classification \
--dataset "wikipedia-detox-250-line-data.tsv" \
--label-column-name "Sentiment" \
--max-exploration-time 120 \
-N wikiBinSentiment
###
```
|Dataset: wikipedia-detox-250-line-data.tsv                                                                      |
|Label : Sentiment                                                                                               |
|Total experiment time : 120.40 Secs                                                                             |
|Total number of models explored: 15                                                                             |
------------------------------------------------------------------------------------------------------------------
|                                              Top 5 models explored                                             |
------------------------------------------------------------------------------------------------------------------
|     Trainer                              Accuracy      AUC    AUPRC  F1-score  Duration #Iteration             |
|1    SgdCalibratedBinary                    0.7368   0.8333   0.9589    0.8387       2.1         12             |
|2    SgdCalibratedBinary                    0.7317   0.8049   0.9033    0.7925       2.0          9             |
|3    LbfgsLogisticRegressionBinary          0.7317   0.8077   0.9055    0.8070       2.0         11             |
|4    LbfgsLogisticRegressionBinary          0.7273   0.9008   0.9005    0.7692       3.2          7             |
|5    LbfgsLogisticRegressionBinary          0.7143   0.7130   0.7520    0.7500       2.1         14             |
------------------------------------------------------------------------------------------------------------------
```

### longer time lead to better auc

# Construct inference console
cd consumeModelApp
dotnet add reference ../SampleBinaryClassification/SampleBinaryClassification.Model/
dotnet add package Microsoft.ML --version 1.3.1
# (optional)
dotnet restore
# change Program.cs in consumeModeApp
dotnet run
```

### Taxi fare regression

```bash
head -n 10 taxi-fare-train.csv

wc -l taxi-fare-train.csv
# 100000

vendor_id,rate_code,passenger_count,trip_time_in_secs,trip_distance,payment_type,fare_amount
CMT,1,1,1271,3.8,CRD,17.5
CMT,1,1,474,1.5,CRD,8

mlnet auto-train \
--task regression \
--dataset "taxi-fare-train.csv" \
--label-column-name "fare_amount" \
--max-exploration-time 30

# result
------------------------------------------------------------------------------------------------------------------
|                                              Top 5 models explored                                             |
------------------------------------------------------------------------------------------------------------------
|     Trainer                             RSquared Absolute-loss Squared-loss RMS-loss  Duration #Iteration      |
|1    FastTreeTweedieRegression             0.9495          0.40         4.79     2.19       9.4         14      |
|2    LightGbmRegression                    0.9472          0.41         5.01     2.24       1.4         15      |
|3    LightGbmRegression                    0.9451          0.41         5.22     2.28       1.1          2      |
|4    FastTreeRegression                    0.9440          0.42         5.32     2.31       1.1          3      |
|5    LightGbmRegression                    0.9383          0.48         5.85     2.42       0.9         12      |
------------------------------------------------------------------------------------------------------------------
```

