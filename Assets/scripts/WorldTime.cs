using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace WorldTime
{

    public class WorldTime : MonoBehaviour
    {
        public event EventHandler<TimeSpan> WorldTimeChanged;
        [SerializeField]
        private float _dayLength; //in minutes

        private TimeSpan _currentTime;
        private float _minuteLength => _dayLength / WorldTimeConstance.MinutesInDay;

        private void Start() 
        {
            StartCoroutine(AddMinute());
        }

     
        private IEnumerator AddMinute()
        {
            _currentTime += TimeSpan.FromMinutes(1);
            WorldTimeChanged?.Invoke(this, _currentTime);
            yield return new WaitForSeconds(_minuteLength);
            StartCoroutine(AddMinute());
        }

    }






}
