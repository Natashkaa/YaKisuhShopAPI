public interface IGoodContainer{
    Task<List<GoodEntity>> GetAllGoods();
    Task<GoodEntity> GetOneGood(int id);
    Task<GoodEntity> Delete(int id);
    Task<GoodEntity> CreateUpdate(GoodEntity newGood);
}