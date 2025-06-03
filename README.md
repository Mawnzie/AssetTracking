This is a console application for tracking "assets". The user is asked to enter "assets". Currently two asset types are allowed; Computer and MobilePhone. (This can be modified in the enumeration type AssetType in Asset.cs).
The Asset class implements the IComparable-interface and the CompareTo()-method, which sorts according to 
1) Name of asset type (Computer > MobilePhone)
2) Date of purchase.
There are 3 locations allowed for the assets: Germany, Sweden and United States (as defined in the enumeration type Location in Asset.cs).
The local prices are adjusted according to an (approximate) currency conversion.
