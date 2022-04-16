using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanillaBlazor.Extensions;

namespace VanillaBlazor
{
    /// <summary>
    /// 类型输入框
    /// </summary>
    public partial class VTypeInput : VInput<object>
    {

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        protected override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            var underlyingType = Nullable.GetUnderlyingType(ValueType) ?? ValueType;

            RenderFragment input<T>(EnumMix<VInputType>? inputType = null) => __builder =>
            {
                var sequence = 0;

                __builder.OpenComponent<VInput<T>>(sequence++);
                __builder.AddAttribute(sequence++, nameof(VInput<T>.InputType), inputType);
                __builder.AddAttribute(sequence++, nameof(VInput<T>.Value), Value is T value ? value : default(T));
                __builder.AddComponent(ref sequence, this);

                __builder.AddAttribute(sequence++, nameof(VInput<T>.OnFocusin), OnFocusin);
                __builder.AddAttribute(sequence++, nameof(VInput<T>.OnEnter), OnEnter);

                __builder.AddAttribute(sequence++, nameof(VInput<T>.Loading), Loading);
                __builder.AddAttribute(sequence++, nameof(VInput<T>.LoadingChanged), LoadingChanged);
                __builder.AddAttribute(sequence++, nameof(VInput<T>.ValueExpression), ValueExpression);
                __builder.AddAttribute(sequence++, nameof(VInput<T>.Placeholder), Placeholder);
                __builder.AddAttribute(sequence++, nameof(VInput<T>.ReadOnly), ReadOnly);
                __builder.AddAttribute(sequence++, nameof(VInput<T>.Format), Format);
                __builder.AddAttribute(sequence++, nameof(VInput<T>.QuickResponse), QuickResponse);

                __builder.AddEvent<T>(ref sequence, nameof(VInput<T>.OnValueChange), this, t => OnValueChange.InvokeAsync(t));
                __builder.AddEvent<T>(ref sequence, nameof(VInput<T>.ValueChanged), this, SetValue<T>);

                if (ChildContent != null && Value != null)
                {
                    __builder.AddContent(sequence++, ChildContent, Value);
                }

                __builder.CloseComponent();
            };

            __builder.OpenComponent<Template>(sequence++);

            __builder.AddAttribute(sequence++, nameof(Template.ChildContent), (RenderFragment)(__builder =>
            {
                var sequence = 0;
                switch (Type.GetTypeCode(underlyingType))
                {
                    case TypeCode.Boolean:
                        {
                            __builder.OpenComponent<VCheckbox>(sequence++);

                            var @checked = Value is bool value ? value : default(bool);
                            __builder.AddAttribute(sequence++, nameof(VCheckbox.Checked), @checked);
                            __builder.AddEvent<bool>(ref sequence, nameof(VCheckbox.ValueChanged), this, SetValue<bool>);

                            __builder.CloseComponent();
                        }
                        break;
                    case TypeCode.Char:
                        if (underlyingType != ValueType)
                            __builder.AddContent(sequence++, input<char?>(VInputType.Number));
                        else
                            __builder.AddContent(sequence++, input<char>(VInputType.Number));
                        break;
                    case TypeCode.SByte:
                        if (underlyingType != ValueType)
                            __builder.AddContent(sequence++, input<sbyte?>(VInputType.Number));
                        else
                            __builder.AddContent(sequence++, input<sbyte>(VInputType.Number));
                        break;
                    case TypeCode.Byte:
                        if (underlyingType != ValueType)
                            __builder.AddContent(sequence++, input<byte?>(VInputType.Number));
                        else
                            __builder.AddContent(sequence++, input<byte>(VInputType.Number));
                        break;
                    case TypeCode.Int16:
                        if (underlyingType != ValueType)
                            __builder.AddContent(sequence++, input<short?>(VInputType.Number));
                        else
                            __builder.AddContent(sequence++, input<short>(VInputType.Number));
                        break;
                    case TypeCode.UInt16:
                        if (underlyingType != ValueType)
                            __builder.AddContent(sequence++, input<ushort?>(VInputType.Number));
                        else
                            __builder.AddContent(sequence++, input<ushort>(VInputType.Number));
                        break;
                    case TypeCode.Int32:
                        if (underlyingType != ValueType)
                            __builder.AddContent(sequence++, input<int?>(VInputType.Number));
                        else
                            __builder.AddContent(sequence++, input<int>(VInputType.Number));
                        break;
                    case TypeCode.UInt32:
                        if (underlyingType != ValueType)
                            __builder.AddContent(sequence++, input<uint?>(VInputType.Number));
                        else
                            __builder.AddContent(sequence++, input<uint>(VInputType.Number));
                        break;
                    case TypeCode.Int64:
                        if (underlyingType != ValueType)
                            __builder.AddContent(sequence++, input<long?>(VInputType.Number));
                        else
                            __builder.AddContent(sequence++, input<long>(VInputType.Number));
                        break;
                    case TypeCode.UInt64:
                        if (underlyingType != ValueType)
                            __builder.AddContent(sequence++, input<ulong?>(VInputType.Number));
                        else
                            __builder.AddContent(sequence++, input<ulong>(VInputType.Number));
                        break;
                    case TypeCode.Single:
                        if (underlyingType != ValueType)
                            __builder.AddContent(sequence++, input<float?>(VInputType.Number));
                        else
                            __builder.AddContent(sequence++, input<float>(VInputType.Number));
                        break;
                    case TypeCode.Double:
                        if (underlyingType != ValueType)
                            __builder.AddContent(sequence++, input<double?>(VInputType.Number));
                        else
                            __builder.AddContent(sequence++, input<double>(VInputType.Number));
                        break;
                    case TypeCode.Decimal:
                        if (underlyingType != ValueType)
                            __builder.AddContent(sequence++, input<decimal?>(VInputType.Number));
                        else
                            __builder.AddContent(sequence++, input<decimal>(VInputType.Number));
                        break;
                    case TypeCode.DateTime:
                        if (underlyingType != ValueType)
                            __builder.AddContent(sequence++, input<DateTime?>(VInputType.Datetime));
                        else
                            __builder.AddContent(sequence++, input<DateTime>(VInputType.Datetime));
                        break;
                    case TypeCode.String:
                        if (underlyingType != ValueType)
                            __builder.AddContent(sequence++, input<string?>(VInputType.Text));
                        else
                            __builder.AddContent(sequence++, input<string>(VInputType.Text));
                        break;
                    default:
                        if(underlyingType == typeof(Guid))
                        {
                            if (underlyingType != ValueType)
                                __builder.AddContent(sequence++, input<Guid?>(VInputType.Text));
                            else
                                __builder.AddContent(sequence++, input<Guid>(VInputType.Text));
                        }
                        break;
                }

            }));

            __builder.CloseComponent();
        };

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="value"></param>
        protected void SetValue<TValue>(TValue value)
        {
            if(Value?.GetType() != typeof(TValue) && Value != null)
            {
                Value = Convert.ChangeType(value, Value.GetType());
            }
            else
            {
                Value = value;
            }
        }
    }
}
