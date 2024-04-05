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

let myPath = "C:/Users/Mia.Meyer/Parquet Files/test.parquet"
// let fileStream = System.IO.File.OpenWrite(myPath)


