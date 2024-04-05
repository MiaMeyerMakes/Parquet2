open Parquet
open Parquet.Data
open Parquet.Schema

open Parquet

// Create file schema
let schema =
    ParquetSchema(
        DataField<int>("id"),
        DataField<string>("city")
    )

// Create data columns with schema metadata and the data you need
let idColumn =
    DataColumn(
        schema.DataFields.[0],
        [| 1; 2 |]
    )
    
let cityColumn =
    DataColumn(
        schema.DataFields.[1],
        [| "London"; "Derby" |]
    )

// Create a new Parquet file

let myPath = @"C:\Users\Mia.Meyer\Parquet Files\test3.parquet"
let fileStream = System.IO.File.OpenWrite(myPath)
fileStream.Close()
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

let fileStreamm = System.IO.File.OpenRead(@"C:\Users\Mia.Meyer\Parquet Files\Titanic.parquet")

// Set Parquet options
let options = ParquetOptions(TreatByteArrayAsString = true)

// Create a Parquet reader
let reader = ParquetReader.CreateAsync(fileStreamm, options).Result

// Read the entire row group (you can adjust this as needed)
let rowGroup = reader.ReadEntireRowGroupAsync().Result

// Print out the data (assuming a single column named 'data')
for row in rowGroup do
    
    let data = row.Data
    printfn "Data: %A" data

//mm 