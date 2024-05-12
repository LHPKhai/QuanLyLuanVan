CREATE OR ALTER TRIGGER CapNhatDiemLuanVan
ON HoiDongChamThi
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted)
    BEGIN
        UPDATE LuanVan
        SET Diem = (
            SELECT AVG(Diem)
            FROM HoiDongChamThi
            WHERE HoiDongChamThi.LuanVanID = LuanVan.ID
        )
        WHERE LuanVan.ID IN (
            SELECT DISTINCT LuanVanID
            FROM inserted
        );
    END;
END;