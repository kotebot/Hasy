using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *
 * САМЫЙ СЛОЖНЫЙ СКРИПТ, мне бы помнить как это все написано(
 * 
 */
public class OpenClose : MonoBehaviour {

    public Subject[] subject;//обьекты для открытия

    public bool gravity;//меняем ли гравитацию
    public bool pointSpawn=false;//если это чекпоинт


    private void OnTriggerEnter2D(Collider2D collision)//вход в триггер
    {
        if (gravity)//обновление гравитации
            Gravity.UpdateGravity();
        for(int i =0; i<subject.Length;i++)
        {
            if (!subject[i].subject.Open)//если обьект он не открыт
                subject[i].Anim.Play(subject[i].Action);//запускаем анимацию
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gravity)
            Gravity.UpdateGravity();//обновляем гравитацию
        for (int i = 0; i < subject.Length; i++)
        {
            if (subject[i].subject.Open&&!subject[i].Opened)//если анимация не проигруется и он октрыт
                subject[i].Anim.Play(subject[i].Action + "Back");//закрываем
            /*
             * ПРОВЕРИТЬ!!!
             * */
            if (subject[i].Opened) subject[i].Anim.Play(subject[i].Action + "Back");//не знаю нах, но менять не хочу пока
        }
        
      
    }

    private void OnCollisionEnter2D(Collision2D collision)//для рычага
    {

        if(collision.collider.tag=="Player"|| collision.collider.tag == "Box")//еслиэто игрок или ящик
        { 
            GetComponentInParent<PivotLever>().Rotate();// обращаемся как родительским компонентам и ищем класс PivotLever и поворачиваем рычаг

            if (pointSpawn)//если это чек поинт то обновляем
                Spawn.UpdatePointSpawn(collision.gameObject);

            for (int i = 0; i < subject.Length; i++)
            {
                if (subject[i].Action != "Jump")//по факту все тоже что и сверху+ пару условий
                {
                    if (subject[i].subject.Open && subject[i].Action != "Transparence")
                        subject[i].Anim.Play(subject[i].Action + "Back");
                    else
                        subject[i].Anim.Play(subject[i].Action);
                }
                else
                {
                    subject[i].subject.activeJump = true;
                }
            }
        }
    }
       
}

//сериализуемый класс для того что бы все поля отображались в инспекторе
[System.Serializable]
public class Subject
{
    public TransformObject subject;//ссылка на класс перелвижаения
    public Animation Anim;//анимация
    public string Action;//действие
    public bool Opened;//открыт ли
}