using Project.Scripts.Player;
using UniRx;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Game.AI.Test
{
    public class ViewAngle : MonoBehaviour //TODO REFACTOR
    {
        [Inject] private PlayerController player;
        
        [Header("Настройки обзора врага")]
    [Range(0, 360)]
    public float viewAngle = 110f; // Угол обзора врага
    public float viewDistance = 10f; // Максимальная дистанция обзора

    [Header("Отображение в редакторе")]
    public bool showGizmos = true; // Переключатель для отрисовки угла обзора в редакторе

    public ReactiveProperty<bool> PlayerDetected { get; private set; } = new();
    
    private void Update()
    {
        // Проверяем, видит ли враг игрока
        DetectPlayer();
    }

    private void DetectPlayer()
    {
        // Получаем направление на игрока относительно позиции врага
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

        // Проверяем угол между направлением взгляда врага и направлением на игрока
        float angleBetween = Vector3.Angle(transform.forward, directionToPlayer);
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer > viewDistance)
        {
            PlayerDetected.Value = false;
        }
        // Если игрок в пределах угла обзора и на допустимом расстоянии
        if (angleBetween < viewAngle / 2f)
        {
            if (distanceToPlayer < viewDistance)
            {
                // Проверяем, не блокируют ли препятствия прямую видимость
                RaycastHit hit;
                if (Physics.Raycast(transform.position, directionToPlayer, out hit, viewDistance))
                {
                    if (hit.transform == player.transform)
                    {
                        PlayerDetected.Value = true;
                    }
                }
            }
        }
    }

    // Отображение угла обзора в редакторе
    private void OnDrawGizmos()
    {
        if (!showGizmos) return;

        // Цвет для угла обзора
        Gizmos.color = Color.yellow;

        // Рисуем сектор, который отображает угол обзора
        DrawFieldOfView();
    }

    private void DrawFieldOfView()
    {
        // Отображаем вектор обзора
        Vector3 forwardLine = transform.forward * viewDistance;
        Gizmos.DrawLine(transform.position, transform.position + forwardLine);

        // Рисуем сектор обзора
        float angleStep = viewAngle / 2f;
        for (float i = -angleStep; i <= angleStep; i += angleStep)
        {
            Quaternion rotation = Quaternion.Euler(0, i, 0);
            Vector3 direction = rotation * forwardLine;
            Gizmos.DrawLine(transform.position, transform.position + direction);
        }

        // Рисуем круг, показывающий максимальную дистанцию обзора
        Gizmos.DrawWireSphere(transform.position, viewDistance);
    }
    }
}
