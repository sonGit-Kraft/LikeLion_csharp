using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShootingGameV2
{
    // 미사일 클래스
    public class Bullet
    {
        public int x;
        public int y;
        public bool fire;
    }

    // 플레이어 클래스
    public class Player
    {
        [DllImport("msvcrt.dll")]
        static extern int _getch();  // c언어 함수 가져옴

        public int playerX; // X 좌표
        public int playerY; // Y 좌표
        public Bullet[] playerBullet = new Bullet[20];
        public Bullet[] playerBullet2 = new Bullet[20];
        public Bullet[] playerBullet3 = new Bullet[20];
        public int Score = 100;
        public Item item = new Item();
        public int itemCount = 0;

        public Player() // 생성자
        {
            // 플레이어 좌표 위치 초기화
            playerX = 0;
            playerY = 12;

            // 총알 초기화
            for (int i = 0; i < 20; i++)
            {
                playerBullet[i] = new Bullet();
                playerBullet[i].x = 0;
                playerBullet[i].y = 0;
                playerBullet[i].fire = false;

                playerBullet2[i] = new Bullet();
                playerBullet2[i].x = 0;
                playerBullet2[i].y = 0;
                playerBullet2[i].fire = false;

                playerBullet3[i] = new Bullet();
                playerBullet3[i].x = 0;
                playerBullet3[i].y = 0;
                playerBullet3[i].fire = false;
            }
        }

        public void GameMain()
        {
            // 키를 입력하는 부분
            KeyControl();
            // 플레이어를 그려주는 부분
            PlayerDraw();

            // UI 점수
            UIscore();

            if (item.ItemLife)
            {
                item.ItemMove();
                item.ItemDraw();
                CrashItem();
            }
        }

        // 키 입력
        public void KeyControl()
        {
            int pressKey; // 키 값

            if (Console.KeyAvailable) // 키가 눌렸을 때 true
            {
                // _getch(): 문자 입력 함수
                pressKey = _getch(); // 아스키값으로 들어옴 (정수형 변수에 들어가기 때문)

                // 밀림 방지
                if (pressKey == 0 || pressKey == 224) // 화살표 키 또는 특수 키 감지
                    pressKey = _getch(); // 실제 키 값 읽기

                switch (pressKey)
                {
                    case 72: // 위쪽 방향 아스키코드
                        playerY--;
                        if (playerY < 1)
                            playerY = 1;
                        break;
                    case 75: // 왼쪽 방향 아스키코드
                        playerX--;
                        if (playerX < 0)
                            playerX = 0;
                        break;
                    case 77: // 오른쪽 방향 아스키코드
                        playerX++;
                        if (playerX > 75)
                            playerX = 75;
                        break;
                    case 80: // 아래쪽 방향 아스키코드
                        playerY++;
                        if (playerY > 21)
                            playerY = 21;
                        break;
                    case 32: // 스페이스바 아스키코드
                        // 총알 발사
                        for (int i = 0; i < 20; i++) // 가운데 미사일
                        {
                            // 미사일이 발사되지 않았다면
                            if (playerBullet[i].fire == false)
                            {
                                playerBullet[i].fire = true; // 미사일이 발사되었다고 기록

                                playerBullet[i].x = playerX + 5; // 플레이어 앞(+5)에서 미사일 쏘기
                                playerBullet[i].y = playerY + 1; // 플레이어 중간 부분 설정 (+1)

                                break; // 한 발씩 발사
                            }
                        }
                        for (int i = 0; i < 20; i++) // 왼쪽 미사일
                        {
                            // 미사일이 발사되지 않았다면
                            if (playerBullet2[i].fire == false)
                            {
                                playerBullet2[i].fire = true; // 미사일이 발사되었다고 기록

                                playerBullet2[i].x = playerX + 5; // 플레이어 앞(+5)에서 미사일 쏘기
                                playerBullet2[i].y = playerY; // 플레이어 왼쪽 부분 설정

                                break; // 한 발씩 발사
                            }
                        }
                        for (int i = 0; i < 20; i++) // 오른쪽 미사일
                        {
                            // 미사일이 발사되지 않았다면
                            if (playerBullet3[i].fire == false)
                            {
                                playerBullet3[i].fire = true; // 미사일이 발사되었다고 기록

                                playerBullet3[i].x = playerX + 5; // 플레이어 앞(+5)에서 미사일 쏘기
                                playerBullet3[i].y = playerY + 2; // 플레이어 오른쪽 부분 설정 (+2)

                                break; // 한 발씩 발사
                            }
                        }
                        break;
                }
            }
        }

        // 플레이어 그리기
        public void PlayerDraw()
        {
            string[] player = new string[]
            {
                "->",
                ">>>",
                "->"
            }; // 문자열 배열로 그리기

            for (int i = 0; i < player.Length; i++)
            {
                // 콘솔 좌표 설정 (playerX, playerY)
                Console.SetCursorPosition(playerX, playerY + i);

                // 문자열 배열 출력
                Console.WriteLine(player[i]);
            }
        }

        // 미사일 그리기
        public void BulletDraw()
        {
            string bullet = "->"; // 미사일

            // 20개
            for (int i = 0; i < 20; i++)
            {
                // 미사일이 살아있는 상태
                if (playerBullet[i].fire == true)
                {
                    // 좌표 설정 -> 중간 위치 보정을 위해 x-1;
                    Console.SetCursorPosition(playerBullet[i].x - 1, playerBullet[i].y);

                    // 총알 출력
                    Console.Write(bullet);

                    // 미사일 오른쪽으로 날라가기
                    playerBullet[i].x++;

                    if (playerBullet[i].x > 78) // 맵을 넘어 갔다면
                    {
                        playerBullet[i].fire = false; // 미사일 false 설정 (다시 준비 상태)
                    }
                }
            }
        }

        public void BulletDraw2()
        {
            string bullet = "->"; // 미사일

            // 20개
            for (int i = 0; i < 20; i++)
            {
                // 미사일이 살아있는 상태
                if (playerBullet2[i].fire == true)
                {
                    // 좌표 설정 -> 중간 위치 보정을 위해 x-1;
                    Console.SetCursorPosition(playerBullet2[i].x - 1, playerBullet2[i].y);

                    // 총알 출력
                    Console.Write(bullet);

                    // 미사일 오른쪽으로 날라가기
                    playerBullet2[i].x++;

                    if (playerBullet2[i].x > 78) // 맵을 넘어 갔다면
                    {
                        playerBullet2[i].fire = false; // 미사일 false 설정 (다시 준비 상태)
                    }
                }
            }
        }

        public void BulletDraw3()
        {
            string bullet = "->"; // 미사일

            // 20개
            for (int i = 0; i < 20; i++)
            {
                // 미사일이 살아있는 상태
                if (playerBullet3[i].fire == true)
                {
                    // 좌표 설정 -> 중간 위치 보정을 위해 x-1;
                    Console.SetCursorPosition(playerBullet3[i].x - 1, playerBullet3[i].y);

                    // 총알 출력
                    Console.Write(bullet);

                    // 미사일 오른쪽으로 날라가기
                    playerBullet3[i].x++;

                    if (playerBullet3[i].x > 78) // 맵을 넘어 갔다면
                    {
                        playerBullet3[i].fire = false; // 미사일 false 설정 (다시 준비 상태)
                    }
                }
            }
        }

        // 충돌 처리
        public void ClashEnemyAndBullet(Enemy enemy)
        {
            // 미사일 20
            for (int i = 0; i < 20; i++)
            {
                if (playerBullet[i].fire == true)
                {
                    // 미사일과 적의 y값이 같을 때
                    if (playerBullet[i].y == enemy.enemyY)
                    {
                        // x좌표 세 칸 중 한칸이라도 충돌 시
                        if (playerBullet[i].x >= (enemy.enemyX - 1)
                            && playerBullet[i].x <= (enemy.enemyX + 1))
                        {
                            Random rand = new Random();
                            enemy.enemyX = 75;
                            enemy.enemyY = rand.Next(2, 22);

                            playerBullet[i].fire = false; // 미사일 준비 상태

                            // 스코어 올리기
                            Score += 100;
                        }
                    }
                }
            }

            // 미사일2 20
            for (int i = 0; i < 20; i++)
            {
                if (playerBullet2[i].fire == true)
                {
                    // 미사일과 적의 y값이 같을 때
                    if (playerBullet2[i].y == enemy.enemyY)
                    {
                        // x좌표 세 칸 중 한칸이라도 충돌 시
                        if (playerBullet2[i].x >= (enemy.enemyX - 1)
                            && playerBullet2[i].x <= (enemy.enemyX + 1))
                        {
                            Random rand = new Random();
                            enemy.enemyX = 75;
                            enemy.enemyY = rand.Next(2, 22);

                            playerBullet2[i].fire = false; // 미사일 준비 상태

                            // 스코어 올리기
                            Score += 100;
                        }
                    }
                }
            }

            // 미사일3 20
            for (int i = 0; i < 20; i++)
            {
                if (playerBullet3[i].fire == true)
                {
                    // 미사일과 적의 y값이 같을 때
                    if (playerBullet3[i].y == enemy.enemyY)
                    {
                        // x좌표 세 칸 중 한칸이라도 충돌 시
                        if (playerBullet3[i].x >= (enemy.enemyX - 1)
                            && playerBullet3[i].x <= (enemy.enemyX + 1))
                        {
                            // 충돌
                            item.ItemLife = true;
                            item.itemX = enemy.enemyX;
                            item.itemY = enemy.enemyY;

                            Random rand = new Random();
                            enemy.enemyX = 75;
                            enemy.enemyY = rand.Next(2, 22);

                            playerBullet3[i].fire = false; // 미사일 준비 상태

                            // 스코어 올리기
                            Score += 100;
                        }
                    }
                }
            }
        }

        public void UIscore()
        {
            Console.SetCursorPosition(63, 0);
            Console.Write("┏━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(63, 1);
            Console.Write("┃              ┃");
            Console.SetCursorPosition(65, 1);
            Console.Write("Score : " + Score);
            Console.SetCursorPosition(63, 2);
            Console.Write("┗━━━━━━━━━━━━━━┛");
        }

        // 아이템 충돌이 일어나면 양쪽미사일 발사
        public void CrashItem()
        {
            if (playerY + 1 == item.itemY)
            {
                if (playerX >= item.itemX - 2 && playerX <= item.itemX + 2)
                {
                    item.ItemLife = false;

                    if (itemCount < 3)
                        itemCount++;

                    for (int i = 0; i < 20; i++) // 총알 초기화
                    {
                        playerBullet[i] = new Bullet();
                        playerBullet[i].x = 0;
                        playerBullet[i].y = 0;
                        playerBullet[i].fire = false;

                        playerBullet2[i] = new Bullet();
                        playerBullet2[i].x = 0;
                        playerBullet2[i].y = 0;
                        playerBullet2[i].fire = false;

                        playerBullet3[i] = new Bullet();
                        playerBullet3[i].x = 0;
                        playerBullet3[i].y = 0;
                        playerBullet3[i].fire = false;
                    }
                }
            }
        }
    }

    // 적 클래스
    public class Enemy
    {
        public int enemyX; // X좌표
        public int enemyY; // Y좌표

        public Enemy() // 생성자
        {
            // 적 좌표 초기화
            enemyX = 77;
            enemyY = 12;
        }

        // 적 그리기
        public void EnemyDraw()
        {
            string enemy = "<-0->"; // 문자열로 표현
            Console.SetCursorPosition(enemyX, enemyY); // 좌표 설정
            Console.Write(enemy); // 출력
        }

        // 적 움직이기
        public void EnemyMove()
        {
            Random rand = new Random();
            enemyX--; // 왼쪽으로 움직임
            if (enemyX < 1) // 왼쪽 끝까지 넘어가면 
            {
                enemyX = 75;
                enemyY = rand.Next(2, 22); // 2 ~ 21
            }
        }
    }

    // 아이템 클래스
    public class Item
    {
        public string ItemName;
        public string ItemSprite;
        public int itemX = 0;
        public int itemY = 0;
        public bool ItemLife = false;

        public void ItemDraw()
        {
            Console.SetCursorPosition(itemX, itemY);
            ItemSprite = "Item★";
            Console.Write(ItemSprite);
        }

        public void ItemMove()
        {
            if (itemX <= 1 || itemY <= 1)
            {
                ItemLife = false;
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false; // 커서 비활성화
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            Player player = new Player(); // 플레이어 생성
            Enemy enemy = new Enemy(); // 적 생성

            // 유니티처럼 프레임 속도
            int dwTime = Environment.TickCount; // 현재 시간 측정 (단위: ms)

            while (true)
            {
                // 0.05 초 지연
                if (dwTime + 50 < Environment.TickCount) // 50ms 가 지났다면
                {
                    dwTime = Environment.TickCount; // 현재 시간 업데이트
                    Console.Clear();

                    // 플레이어
                    player.GameMain();

                    // 총알
                    if (player.itemCount == 0)
                    {
                        player.BulletDraw();
                    }
                    else if (player.itemCount == 1)
                    {
                        player.BulletDraw();
                        player.BulletDraw2();
                    }
                    else
                    {
                        player.BulletDraw();
                        player.BulletDraw2();
                        player.BulletDraw3();
                    }

                    // 적
                    enemy.EnemyMove();
                    enemy.EnemyDraw();

                    // 충돌 처리
                    player.ClashEnemyAndBullet(enemy);
                }
            }
        }
    }
}