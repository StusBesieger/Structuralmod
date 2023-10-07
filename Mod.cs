using System;
using Modding;
using UnityEngine;

namespace StructuralSpace
{
	public class Mod : ModEntryPoint
	{
		public override void OnLoad()
		{
			// Called when the mod is loaded.
		}
	}
	public class StructuralBoxScript : BlockScript
	{
		private Rigidbody rigidbody;
		private float mass = 1f;
		Vector3 volume;
		private Color blockColor = new Color(1f, 1f, 1f);
		private MColourSlider BlockColorSlider;
		public Vector3 defaultScale = Vector3.zero;
		public float jointcomponent= 0.05f;
		private SphereCollider scollider;

		private void Color_ValueChanged(Color value)
		{
			base.BlockBehaviour.MeshRenderer.material.color = value;
		}
		public override void OnBlockPlaced()
		{
			Transform transform = base.transform.Find("Occluder");
			if (transform != null)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}
			transform = base.transform.Find("Adding Point");
			if (transform != null)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}
			ConfigurableJoint component = GetComponent<ConfigurableJoint>();
			if (component != null)
			{
			}
			transform = base.transform.Find("TriggerForJoint");
			if (transform != null)
			{
				transform.GetComponent<SphereCollider>().radius = 1f;
			}
			transform = base.transform.Find("StickyJointTrigger");
			if (transform != null)
			{
				transform.localScale = Vector3.one;
			}
			component = transform.GetChild(0).GetComponent<ConfigurableJoint>();
			if (component != null)
			{
				float num2 = (component.breakForce = (component.breakTorque = base.gameObject.GetComponent<ConfigurableJoint>().breakForce));
			}
			transform = base.transform.Find("Colliders/Box Collider");
			if (transform != null)
			{
				transform.gameObject.layer = 12;
				transform.transform.parent = base.transform;
			}
			transform = base.transform.Find("Colliders");
			if (transform != null)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}
			defaultScale = transform.lossyScale;
			Transform jointtransform = base.transform.Find("StickyJointTrigger");
		}
		public override void SafeAwake()
		{
			rigidbody = GetComponent<Rigidbody>();
			volume = transform.localScale;
			mass = volume.x * volume.y * volume.z * 0.5f + 1.5f;
			BlockColorSlider = AddColourSlider("Color", "color", Color.white, snapColors: false);
			BlockColorSlider.ValueChanged += Color_ValueChanged;
			Transform jointtransform = base.transform.Find("StickyJointTrigger");
			Vector3 lossScale = jointtransform.lossyScale;
			scollider = jointtransform.GetComponent<SphereCollider>();
			if (jointtransform != null)
            {
				scollider.radius = jointcomponent / Math.Max(Math.Max(lossScale.x, lossScale.y), lossScale.z);
			}
			Transform basejointtransform = base.transform.Find("TriggerForJoint");
			Vector3 baselocalScale = basejointtransform.localScale;
			lossScale = basejointtransform.lossyScale;
			scollider = basejointtransform.GetComponent<SphereCollider>();
			if (basejointtransform != null)
			{
				scollider.radius = baselocalScale.x / Math.Max(Math.Max(lossScale.x, lossScale.y), lossScale.z);
			}
		}

		public void Start()
        {
			Console.WriteLine(mass);
			rigidbody.mass = mass;
			Color_ValueChanged(BlockColorSlider.Value);
		}
	}
	public class StructuralCylinderScript : BlockScript
	{
		private Rigidbody rigidbody;
		private float mass = 1f;
		Vector3 volume;
		private Color blockColor = new Color(1f, 1f, 1f);
		private MColourSlider BlockColorSlider;
		public Vector3 defaultScale = Vector3.zero;
		public float jointcomponent = 0.05f;
		private SphereCollider scollider;
		private void Color_ValueChanged(Color value)
		{
			base.BlockBehaviour.MeshRenderer.material.color = value;
		}
		public override void OnBlockPlaced()
		{
			Transform transform = base.transform.Find("Occluder");
			if (transform != null)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}
			transform = base.transform.Find("Adding Point");
			if (transform != null)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}
			ConfigurableJoint component = GetComponent<ConfigurableJoint>();
			if (component != null)
			{
			}
			transform = base.transform.Find("TriggerForJoint");
			if (transform != null)
			{
				transform.GetComponent<SphereCollider>().radius = 1f;
			}
			transform = base.transform.Find("StickyJointTrigger");
			if (transform != null)
			{
				transform.localScale = Vector3.one;
			}
			component = transform.GetChild(0).GetComponent<ConfigurableJoint>();
			if (component != null)
			{
				float num2 = (component.breakForce = (component.breakTorque = base.gameObject.GetComponent<ConfigurableJoint>().breakForce));
			}
			transform = base.transform.Find("Colliders");
			int childCount = transform.childCount;
			if (transform != null)
			{
				for (int i = 0; i < childCount; i++ ){
					Transform child = transform.GetChild(0);
					child.gameObject.layer = 12;
					child.parent = base.transform;
				
				}
			}
			transform = base.transform.Find("Colliders");
			if (transform != null)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}
			Debug.Log("stus 1");

		}
		public override void SafeAwake()
		{

			rigidbody = GetComponent<Rigidbody>();
			volume = transform.localScale;
			mass = volume.x * volume.y * volume.z * 0.25f * 3.14f * 0.5f + 1.5f;
			BlockColorSlider = AddColourSlider("Color", "color", Color.white, snapColors: false);
			BlockColorSlider.ValueChanged += Color_ValueChanged;
			Transform jointtransform = base.transform.Find("StickyJointTrigger");
			Vector3 lossScale = jointtransform.lossyScale;
			scollider = jointtransform.GetComponent<SphereCollider>();
			if (jointtransform != null)
			{
				scollider.radius = jointcomponent / Math.Max(Math.Max(lossScale.x, lossScale.y), lossScale.z);
			}
			Transform basejointtransform = base.transform.Find("TriggerForJoint");
			Vector3 baselocalScale = basejointtransform.localScale;
			lossScale = basejointtransform.lossyScale;
			scollider = basejointtransform.GetComponent<SphereCollider>();
			if (basejointtransform != null)
			{
				scollider.radius = baselocalScale.x / Math.Max(Math.Max(lossScale.x, lossScale.y), lossScale.z);
			}
		}
		public void Start()
		{
			Console.WriteLine(mass);
			rigidbody.mass = mass;
			Color_ValueChanged(BlockColorSlider.Value);
		}
	}
	public class StructuralBoxHpHaveScript : BlockScript
	{
		private Rigidbody rigidbody;
		private float mass = 1f;
        Vector3 volume;
		private BlockBehaviour block;
		private Color blockColor = new Color(1f, 1f, 1f);
		private MColourSlider BlockColorSlider;
		public Vector3 defaultScale = Vector3.zero;
		public float jointcomponent = 0.05f;
		private SphereCollider scollider;
		private void Color_ValueChanged(Color value)
		{
			base.BlockBehaviour.MeshRenderer.material.color = value;
		}
		public override void OnBlockPlaced()
		{
			Transform transform = base.transform.Find("Occluder");
			if (transform != null)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}
			transform = base.transform.Find("Adding Point");
			if (transform != null)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}
			ConfigurableJoint component = GetComponent<ConfigurableJoint>();
			if (component != null)
			{
			}
			transform = base.transform.Find("TriggerForJoint");
			if (transform != null)
			{
				transform.GetComponent<SphereCollider>().radius = 1f;
			}
			transform = base.transform.Find("StickyJointTrigger");
			if (transform != null)
			{
				transform.localScale = Vector3.one;
			}
			component = transform.GetChild(0).GetComponent<ConfigurableJoint>();
			if (component != null)
			{
				float num2 = (component.breakForce = (component.breakTorque = base.gameObject.GetComponent<ConfigurableJoint>().breakForce));
			}
			transform = base.transform.Find("Colliders/Box Collider");
			if (transform != null)
			{
				transform.gameObject.layer = 12;
				transform.transform.parent = base.transform;
			}
			transform = base.transform.Find("Colliders");
			if (transform != null)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}

		}
		public override void SafeAwake()
		{

			rigidbody = GetComponent<Rigidbody>();
			volume = transform.localScale;
			mass = volume.x * volume.y * volume.z * 0.1f + 1.5f;
			BlockColorSlider = AddColourSlider("Color", "color", Color.white, snapColors: false);
			BlockColorSlider.ValueChanged += Color_ValueChanged;
			Transform jointtransform = base.transform.Find("StickyJointTrigger");
			Vector3 lossScale = jointtransform.lossyScale;
			scollider = jointtransform.GetComponent<SphereCollider>();
			if (jointtransform != null)
			{
				scollider.radius = jointcomponent / Math.Max(Math.Max(lossScale.x, lossScale.y), lossScale.z);
			}
			Transform basejointtransform = base.transform.Find("TriggerForJoint");
			Vector3 baselocalScale = basejointtransform.localScale;
			lossScale = basejointtransform.lossyScale;
			scollider = basejointtransform.GetComponent<SphereCollider>();
			if (basejointtransform != null)
			{
				scollider.radius = baselocalScale.x / Math.Max(Math.Max(lossScale.x, lossScale.y), lossScale.z);
			}
		}
		public void Start()
		{
			Console.WriteLine(mass);
			rigidbody.mass = mass;
			block = GetComponent<BlockBehaviour>();
			Color_ValueChanged(BlockColorSlider.Value);
		} 
		public void FixedUpdate()
        {
			float hp;
			if (this.gameObject.activeSelf)
			{
				hp = block.BlockHealth.health;
				if (hp <= 0.01 && hp >= -0.01)
                {
					rigidbody.mass = mass * 5f;
					hp = -1.00f;
                }
			}
		}
	}
	public class StructuralCylinderHpHaveScript : BlockScript
	{
		private Rigidbody rigidbody;
		private float mass = 1f;
        Vector3 volume;
		private BlockBehaviour block;
		private Color blockColor = new Color(1f, 1f, 1f);
		private MColourSlider BlockColorSlider;
		public Vector3 defaultScale = Vector3.zero;
		public float jointcomponent = 0.05f;
		private SphereCollider scollider;
		private void Color_ValueChanged(Color value)
		{
			base.BlockBehaviour.MeshRenderer.material.color = value;
		}
		public override void OnBlockPlaced()
		{
			Transform transform = base.transform.Find("Occluder");
			if (transform != null)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}
			transform = base.transform.Find("Adding Point");
			if (transform != null)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}
			ConfigurableJoint component = GetComponent<ConfigurableJoint>();
			if (component != null)
			{
			}
			transform = base.transform.Find("TriggerForJoint");
			if (transform != null)
			{
				transform.GetComponent<SphereCollider>().radius = 1f;
			}
			transform = base.transform.Find("StickyJointTrigger");
			if (transform != null)
			{
				transform.localScale = Vector3.one;
			}
			component = transform.GetChild(0).GetComponent<ConfigurableJoint>();
			if (component != null)
			{
				float num2 = (component.breakForce = (component.breakTorque = base.gameObject.GetComponent<ConfigurableJoint>().breakForce));
			}
			transform = base.transform.Find("Colliders");
			int childCount = transform.childCount;
			if (transform != null)
			{
				for (int i = 0; i < childCount; i++)
				{
					Transform child = transform.GetChild(0);
					child.gameObject.layer = 12;
					child.parent = base.transform;

				}
			}
			transform = base.transform.Find("Colliders");
			if (transform != null)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}

		}
		public override void SafeAwake()
		{

			rigidbody = GetComponent<Rigidbody>();
			volume = transform.localScale;
			mass = volume.x * volume.y * volume.z * 0.25f * 3.14f * 0.1f + 1.5f;
			BlockColorSlider = AddColourSlider("Color", "color", Color.white, snapColors: false);
			BlockColorSlider.ValueChanged += Color_ValueChanged;
			Transform jointtransform = base.transform.Find("StickyJointTrigger");
			Vector3 lossScale = jointtransform.lossyScale;
			scollider = jointtransform.GetComponent<SphereCollider>();
			if (jointtransform != null)
			{
				scollider.radius = jointcomponent / Math.Max(Math.Max(lossScale.x, lossScale.y), lossScale.z);
			}
			Transform basejointtransform = base.transform.Find("TriggerForJoint");
			Vector3 baselocalScale = basejointtransform.localScale;
			lossScale = basejointtransform.lossyScale;
			scollider = basejointtransform.GetComponent<SphereCollider>();
			if (basejointtransform != null)
			{
				scollider.radius = baselocalScale.x / Math.Max(Math.Max(lossScale.x, lossScale.y), lossScale.z);
			}
		}
        public void Start()
		{
			Console.WriteLine(mass);
			rigidbody.mass = mass;
			block = GetComponent<BlockBehaviour>();
			Color_ValueChanged(BlockColorSlider.Value);
		}
		public void FixedUpdate()
		{
			float hp;
			if (this.gameObject.activeSelf)
			{
				hp = block.BlockHealth.health;
				if (hp <= 0.01 && hp >= -0.01)
				{
					rigidbody.mass = mass * 5f;
					hp = -1.00f;
				}
			}
		}
	}
}
