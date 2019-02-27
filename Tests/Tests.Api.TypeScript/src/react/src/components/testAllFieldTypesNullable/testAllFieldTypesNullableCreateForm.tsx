import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TestAllFieldTypesNullableMapper from './testAllFieldTypesNullableMapper';
import TestAllFieldTypesNullableViewModel from './testAllFieldTypesNullableViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';

interface TestAllFieldTypesNullableCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface TestAllFieldTypesNullableCreateComponentState {
  model?: TestAllFieldTypesNullableViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class TestAllFieldTypesNullableCreateComponent extends React.Component<
  TestAllFieldTypesNullableCreateComponentProps,
  TestAllFieldTypesNullableCreateComponentState
> {
  state = {
    model: new TestAllFieldTypesNullableViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false
  };

 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as TestAllFieldTypesNullableViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:TestAllFieldTypesNullableViewModel) =>
  {  
    let mapper = new TestAllFieldTypesNullableMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.TestAllFieldTypesNullables,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<
            Api.TestAllFieldTypesNullableClientRequestModel
          >;
          this.setState({...this.state, submitted:true, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
          if(error.response.data)
          {
			  let errorResponse = error.response.data as ActionResponse; 

			  errorResponse.validationErrors.forEach(x =>
			  {
				this.props.form.setFields({
				 [ToLowerCaseFirstLetter(x.propertyName)]: {
				  value:this.props.form.getFieldValue(ToLowerCaseFirstLetter(x.propertyName)),
				  errors: [new Error(x.errorMessage)]
				},
				})
			  });
		  }
          this.setState({...this.state, submitted:true, errorOccurred:true, errorMessage:'Error from API'});
        }
      ); 
  }
  
  render() {

    const { getFieldDecorator, getFieldsError, getFieldError, isFieldTouched } = this.props.form;
        
    let message:JSX.Element = <div></div>;
    if(this.state.submitted)
    {
      if (this.state.errorOccurred) {
        message = <Alert message={this.state.errorMessage} type='error' />;
      }
      else
      {
        message = <Alert message='Submitted' type='success' />;
      }
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } 
    else if (this.state.loaded) {

        return ( 
         <Form onSubmit={this.handleSubmit}>
            			<Form.Item>
              <label htmlFor='fieldBigInt'>FieldBigInt</label>
              <br />             
              {getFieldDecorator('fieldBigInt', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldBigInt"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldBinary'>FieldBinary</label>
              <br />             
              {getFieldDecorator('fieldBinary', {
              rules:[{ max: 50, message: 'Exceeds max length of 50' },
],
              
              })
              ( <Input placeholder={"FieldBinary"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldBit'>FieldBit</label>
              <br />             
              {getFieldDecorator('fieldBit', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldBit"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldChar'>FieldChar</label>
              <br />             
              {getFieldDecorator('fieldChar', {
              rules:[{ max: 10, message: 'Exceeds max length of 10' },
],
              
              })
              ( <Input placeholder={"FieldChar"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldDate'>FieldDate</label>
              <br />             
              {getFieldDecorator('fieldDate', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldDateTime'>FieldDateTime</label>
              <br />             
              {getFieldDecorator('fieldDateTime', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldDateTime"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldDateTime2'>FieldDateTime2</label>
              <br />             
              {getFieldDecorator('fieldDateTime2', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldDateTime2"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldDateTimeOffset'>FieldDateTimeOffset</label>
              <br />             
              {getFieldDecorator('fieldDateTimeOffset', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldDateTimeOffset"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldDecimal'>FieldDecimal</label>
              <br />             
              {getFieldDecorator('fieldDecimal', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldDecimal"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldFloat'>FieldFloat</label>
              <br />             
              {getFieldDecorator('fieldFloat', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldFloat"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldImage'>FieldImage</label>
              <br />             
              {getFieldDecorator('fieldImage', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldImage"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldMoney'>FieldMoney</label>
              <br />             
              {getFieldDecorator('fieldMoney', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldMoney"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldNChar'>FieldNChar</label>
              <br />             
              {getFieldDecorator('fieldNChar', {
              rules:[{ max: 10, message: 'Exceeds max length of 10' },
],
              
              })
              ( <Input placeholder={"FieldNChar"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldNText'>FieldNText</label>
              <br />             
              {getFieldDecorator('fieldNText', {
              rules:[{ max: 1073741823, message: 'Exceeds max length of 1073741823' },
],
              
              })
              ( <Input placeholder={"FieldNText"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldNumeric'>FieldNumeric</label>
              <br />             
              {getFieldDecorator('fieldNumeric', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldNumeric"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldNVarchar'>FieldNVarchar</label>
              <br />             
              {getFieldDecorator('fieldNVarchar', {
              rules:[{ max: 50, message: 'Exceeds max length of 50' },
],
              
              })
              ( <Input placeholder={"FieldNVarchar"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldReal'>FieldReal</label>
              <br />             
              {getFieldDecorator('fieldReal', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldReal"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldSmallDateTime'>FieldSmallDateTime</label>
              <br />             
              {getFieldDecorator('fieldSmallDateTime', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldSmallDateTime"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldSmallInt'>FieldSmallInt</label>
              <br />             
              {getFieldDecorator('fieldSmallInt', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldSmallInt"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldSmallMoney'>FieldSmallMoney</label>
              <br />             
              {getFieldDecorator('fieldSmallMoney', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldSmallMoney"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldText'>FieldText</label>
              <br />             
              {getFieldDecorator('fieldText', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldText"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldTime'>FieldTime</label>
              <br />             
              {getFieldDecorator('fieldTime', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldTime"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldTimestamp'>FieldTimestamp</label>
              <br />             
              {getFieldDecorator('fieldTimestamp', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldTimestamp"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldTinyInt'>FieldTinyInt</label>
              <br />             
              {getFieldDecorator('fieldTinyInt', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldTinyInt"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldUniqueIdentifier'>FieldUniqueIdentifier</label>
              <br />             
              {getFieldDecorator('fieldUniqueIdentifier', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldUniqueIdentifier"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldVarBinary'>FieldVarBinary</label>
              <br />             
              {getFieldDecorator('fieldVarBinary', {
              rules:[{ max: 50, message: 'Exceeds max length of 50' },
],
              
              })
              ( <Input placeholder={"FieldVarBinary"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldVarchar'>FieldVarchar</label>
              <br />             
              {getFieldDecorator('fieldVarchar', {
              rules:[{ max: 50, message: 'Exceeds max length of 50' },
],
              
              })
              ( <Input placeholder={"FieldVarchar"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldXML'>FieldXML</label>
              <br />             
              {getFieldDecorator('fieldXML', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldXML"} /> )}
              </Form.Item>

			
          <Form.Item>
            <Button type="primary" htmlType="submit">
                Submit
              </Button>
            </Form.Item>
			{message}
        </Form>);
    } else {
      return null;
    }
  }
}

export const WrappedTestAllFieldTypesNullableCreateComponent = Form.create({ name: 'TestAllFieldTypesNullable Create' })(TestAllFieldTypesNullableCreateComponent);

/*<Codenesium>
    <Hash>141acd8359d465eecfc79a62d3e9855a</Hash>
</Codenesium>*/