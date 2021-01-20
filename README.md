## Welcome

Welcome to the C# katas repo!

`Katas.sln` contains two projects - `KatasProject` and `Test`. `KatasProject` contains both the methods you need to complete (`Katas.cs`) and a few classes that are used by those methods (`Models.cs`).

`Test` contains `KatasTest` - where you'll be writing your unit tests. Some unit tests for `AreCatsDominant` have been provided.

## Katas

### AreCatsDominant
Takes a mixed list of Animals - Dogs and Cats. Return `true` if most are cats, `false` if most are dogs, `null` if equal.

### ConvertToSassCase
Takes a string, returns a sassy version of the string (alternating lower/upper case characters)
e.g. `thanks for the coffee` gets turned into `tHaNkS FoR ThE CoFfEe`.

### CheckHeight
Take a List of customers, filters out those with `HeightCM` under 161.

### TwitterFeedAnalysis
Takes a collection of strings, checks each string for any mentions (strings starting with `@`) + hashtags (strings starting with `#`), returns a dictionary of mentions + hashtags with a count
e.g. a single string `@realDonaldTrump u ok hun?` returns a dictionary with `<"@realDonaldTrump", 1>` as the only key/value pair.
e.g. two strings `bored of #lockdown + #covid`, `hating #covid` returns a dictionary with `<"#lockdown", 1>`  and `<"#covid", 2>` key/value pairs.

### UpdateUserNotes
Takes a collection of users and a collection of up-to-date notes, returns a list of users with their notes updated
e.g. a user with a single note `buy milk`, and a corresponding updated note `now buy more milk`. Match based on note id.

### CategoriseCustomerIds
Takes a list of customers and a list of Guids (unique ids), returns a dictionary of categorised customer ids.
`deprecated`: customer ids that are not Guids
`current`: customer ids that exist in the currentGuids list
`legacy`: customer ids that aren't in the currentGuids list

### TriageArtworks
Takes a list of artwork submissions and a cut-off date, returns an array of the first three to be submitted on time.