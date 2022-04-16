using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VanillaBlazor.Extensions;

namespace VanillaBlazor
{
    /// <summary>
    /// 表单控件具有HTML元素级定义的全局样式。  
    /// Form controls have global styling defined at the HTML element level.
    /// </summary>
    public partial class VForm<TModel> : VContentComponentBase<TModel>, IVForm
    {
        /// <summary>
        /// 表单项
        /// </summary>
        private IList<IVField> Fields = new List<IVField>();

        /// <summary>
        /// 控制值
        /// </summary>
        protected IList<IControlValueAccessor> Controls = new List<IControlValueAccessor>();

        /// <summary>
        /// 编辑上下文
        /// </summary>
        public EditContext EditContext => _editContext;
        private EditContext _editContext;   

        /// <summary>
        /// 模型
        /// </summary>
        object IVForm.Model => Model;

        /// <summary>
        /// 设置
        /// </summary>
        protected override void OnSet()
        {
            var fixedClass = "p-form";
            ClassMapper.Clear()
            .Add(fixedClass)
            .If("p-form--inline", () => Inline)
            .If("p-form--stacked", () => Stacked)
            ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        protected virtual RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenComponent<EditForm>(sequence++);
            __builder.AddComponent(ref sequence, this);

            __builder.AddAttribute(sequence++, nameof(EditForm.EditContext), _editContext);

            __builder.AddEvent<EditContext>(ref sequence, nameof(EditForm.OnValidSubmit), this, HandleOnValidSubmit);
            __builder.AddEvent<EditContext>(ref sequence, nameof(EditForm.OnInvalidSubmit), this, HandleOnInvalidSubmit);

            __builder.AddAttribute(sequence++, nameof(EditForm.ChildContent), (RenderFragment<EditContext>)(context => __builder =>
            {
                var sequence = 0;

                __builder.OpenComponent<DataAnnotationsValidator>(sequence++);
                __builder.CloseComponent();

                __builder.OpenComponent<CascadingValue<IVForm>>(sequence++);
                __builder.AddAttribute(sequence++, nameof(CascadingValue<IVForm>.Value), this);
                __builder.AddAttribute(sequence++, nameof(CascadingValue<IVForm>.IsFixed), true);

                __builder.AddAttribute(sequence++, nameof(CascadingValue<IVForm>.ChildContent), (RenderFragment)(__builder =>
                {
                    var sequence = 0;

                    if (Auto && Model != null)
                    {
                        __builder.AddContent(sequence++, AuotField());
                    }

                    if (ChildContent != null && Model != null)
                    {
                        __builder.AddContent(sequence++, ChildContent, Model);
                    }
                }));

                __builder.CloseComponent();
            }));

            __builder.CloseComponent();
        };

        /// <summary>
        /// 自动
        /// </summary>
        /// <returns></returns>
        protected virtual RenderFragment AuotField() => __builder =>
        {
            var type = typeof(TModel);
            var properties = type
                .GetProperties()
                .OrderByDescending(propertie => propertie.GetCustomAttribute<DisplayAttribute>()?.GetOrder() ?? 0)
                ;

            var sequence = 0;

            RenderFragment field(PropertyInfo property) => __builder =>
            {
                var sequence = 0;

                var value = property.GetValue(Model);
                var name = property.GetCustomAttribute<DisplayAttribute>()?.GetName() ??
                property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? property.Name;
                var required = property.GetCustomAttributes(typeof(RequiredAttribute), true).Any();
                var readOnly = property.GetCustomAttribute<ReadOnlyAttribute>()?.IsReadOnly ?? false;
                var underlyingType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                __builder.OpenComponent<CascadingValue<string>>(sequence++);
                __builder.AddAttribute(sequence++, nameof(CascadingValue<IVForm>.Value), property.Name);
                __builder.AddAttribute(sequence++, nameof(CascadingValue<IVForm>.IsFixed), true);
                __builder.AddAttribute(sequence++, nameof(CascadingValue<IVForm>.Name), "FieldName");
                __builder.AddAttribute(sequence++, nameof(CascadingValue<IVForm>.ChildContent), (RenderFragment)(__builder =>
                {
                    var sequence = 0;

                    __builder.OpenComponent<VField>(sequence++);
                    __builder.AddAttribute(sequence++, nameof(VField.Label), name);
                    __builder.AddAttribute(sequence++, nameof(VField.Required), required);

                    __builder.AddAttribute(sequence++, nameof(VField.ChildContent), (RenderFragment)(__builder =>
                    {
                        var sequence = 0;

                        if (underlyingType.IsEnum)
                        {
                            var names = underlyingType.GetEnumDisplayNames();

                            __builder.OpenComponent<VSelect>(sequence++);
                            __builder.AddAttribute(sequence++, nameof(VSelect.SelectedKeys), new string[] { value?.ToString() });
                            __builder.AddAttribute(sequence++, nameof(VSelect.Disabled), readOnly);
                            Action<string[]> setEnum = keys =>
                            {
                                if (keys?.Any() ?? false)
                                {
                                    property.SetValue(Model, Enum.Parse(underlyingType, keys[0]));
                                }
                                else if (underlyingType != property.PropertyType)
                                {
                                    property.SetValue(Model, null);
                                }
                            };
                            __builder.AddEvent(ref sequence, nameof(VSelect.OnSelectedKeysChange), this, setEnum);

                            __builder.AddAttribute(sequence++, nameof(VField.ChildContent), (RenderFragment)(__builder =>
                            {
                                foreach (var name in names)
                                {
                                    __builder.OpenComponent<VSelectOption>(sequence++);
                                    __builder.AddAttribute(sequence++, nameof(VSelectOption.Key), name.Key);
                                    __builder.AddAttribute(sequence++, nameof(VSelectOption.Value), name.Value);
                                    __builder.CloseComponent();
                                }
                            }));

                            __builder.CloseComponent();
                        }
                        else
                        {
                            __builder.OpenComponent<VTypeInput>(sequence++);
                            __builder.AddAttribute(sequence++, nameof(VTypeInput.ReadOnly), readOnly);
                            __builder.AddAttribute(sequence++, nameof(VTypeInput.ValueType), property.PropertyType);
                            __builder.AddAttribute(sequence++, nameof(VTypeInput.Value), value);
                            Action<object> setValue = v => property.SetValue(Model, v);
                            __builder.AddAttribute(sequence++, nameof(VTypeInput.ValueChanged), EventCallback.Factory.Create<object>(this, setValue));
                            __builder.CloseComponent();
                        }
                    }));
                    __builder.CloseComponent();
                }));

                __builder.CloseComponent();
            };

            __builder.OpenComponent<Template>(sequence++);

            __builder.AddAttribute(sequence++, nameof(Template.ChildContent), (RenderFragment)(__builder =>
            {
                var sequence = 0;

                foreach (var propertie in properties)
                {
                    if (!propertie.CanRead || !propertie.CanWrite)
                        continue;
                    if (!(propertie.GetCustomAttribute<DisplayAttribute>()?.GetAutoGenerateField() ?? true))
                        continue;

                    __builder.AddContent(sequence++, field(propertie));
                }
            }));

            __builder.CloseComponent();
        };

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            foreach (var control in Controls)
            {
                control.Reset();
            }
            _editContext = new EditContext(Model);
            OnReset.InvokeAsync(_editContext);
        }

        /// <summary>
        /// 提交
        /// </summary>
        public void Submit()
        {
            var isValid = Validate();
            if (isValid && OnFinish.HasDelegate)
                OnFinish.InvokeAsync(_editContext);
            else if (OnFailed.HasDelegate)
                OnFailed.InvokeAsync(_editContext);
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            return _editContext?.Validate() ?? false;
        }

        /// <summary>
        /// 添加表单项
        /// </summary>
        /// <param name="field"></param>
        void IVForm.AddFormItem(IVField field)
        {
            Fields.Add(field);
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="valueAccessor"></param>
        void IVForm.AddControl(IControlValueAccessor valueAccessor)
        {
            Controls.Add(valueAccessor);
        }

        #region Handle

        /// <summary>
        /// 在有效的提交
        /// </summary>
        /// <param name="editContext"></param>
        /// <returns></returns>
        private async Task HandleOnValidSubmit(EditContext editContext)
        {
            await OnFinish.InvokeAsync(editContext);
        }

        /// <summary>
        /// 在无效的提交
        /// </summary>
        /// <param name="editContext"></param>
        /// <returns></returns>
        private async Task HandleOnInvalidSubmit(EditContext editContext)
        {
            await OnFailed.InvokeAsync(editContext);
        }

        #endregion
    }
}
