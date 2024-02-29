SELECT
O.Id, BR.Description AS Make, M.Description AS Model, SM.Description AS Submodel, C.[Year], C.ZipCode, B.[Name] AS BuyerName, B.Amount AS Quote, S.Description AS [Status], O.PickedUpDate
FROM Orders O
JOIN Buyers B ON B.Id = O.BuyerId
JOIN Statuses S ON S.Id = O.StatusId
JOIN Cars C ON C.Id = O.CarId
JOIN Brands BR ON BR.Id = C.MakeId
JOIN Models M ON M.Id = C.ModelId
JOIN Submodels SM ON SM.Id = C.SubmodelId
