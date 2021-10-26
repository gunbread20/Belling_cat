public enum GameState
{
    Main, // 메인 메뉴
    Start, 
    Standby, // 일시정지 후, 혹은 그 외의 이유로 정지 후 실행할 경우
    Shop, // 상점 화면에 들어갔을 경우
    Running, // 게임 실행중
    Over, // 게임 오버
    Error

}