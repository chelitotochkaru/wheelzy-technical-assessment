SELECT
S.Id, BR.Description AS Make, M.Description AS Model, SM.Description AS Submodel, C.[Year], C.ZipCode, B.[Name] AS BuyerName, B.Amount AS Quote, SS.Description AS [Status], S.PickedUpDate
FROM Sells S
JOIN Buyers B ON B.Id = S.BuyerId
JOIN Statuses SS ON SS.Id = S.StatusId
JOIN Cars C ON C.Id = S.CarId
JOIN Brands BR ON BR.Id = C.MakeId
JOIN Models M ON M.Id = C.ModelId
JOIN Submodels SM ON SM.Id = C.SubmodelId
