import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TestAllFieldTypesNullableMapper from './testAllFieldTypesNullableMapper';
import TestAllFieldTypesNullableViewModel from './testAllFieldTypesNullableViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
              ( <Input placeholder={"FieldBigInt"} id={"fieldBigInt"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldBinary'>FieldBinary</label>
              <br />             
              {getFieldDecorator('fieldBinary', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldBinary"} id={"fieldBinary"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldBit'>FieldBit</label>
              <br />             
              {getFieldDecorator('fieldBit', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldBit"} id={"fieldBit"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldChar'>FieldChar</label>
              <br />             
              {getFieldDecorator('fieldChar', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldChar"} id={"fieldChar"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldDate'>FieldDate</label>
              <br />             
              {getFieldDecorator('fieldDate', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldDate"} id={"fieldDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldDateTime'>FieldDateTime</label>
              <br />             
              {getFieldDecorator('fieldDateTime', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldDateTime"} id={"fieldDateTime"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldDateTime2'>FieldDateTime2</label>
              <br />             
              {getFieldDecorator('fieldDateTime2', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldDateTime2"} id={"fieldDateTime2"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldDateTimeOffset'>FieldDateTimeOffset</label>
              <br />             
              {getFieldDecorator('fieldDateTimeOffset', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldDateTimeOffset"} id={"fieldDateTimeOffset"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldDecimal'>FieldDecimal</label>
              <br />             
              {getFieldDecorator('fieldDecimal', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldDecimal"} id={"fieldDecimal"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldFloat'>FieldFloat</label>
              <br />             
              {getFieldDecorator('fieldFloat', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldFloat"} id={"fieldFloat"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldImage'>FieldImage</label>
              <br />             
              {getFieldDecorator('fieldImage', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldImage"} id={"fieldImage"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldMoney'>FieldMoney</label>
              <br />             
              {getFieldDecorator('fieldMoney', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldMoney"} id={"fieldMoney"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldNChar'>FieldNChar</label>
              <br />             
              {getFieldDecorator('fieldNChar', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldNChar"} id={"fieldNChar"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldNText'>FieldNText</label>
              <br />             
              {getFieldDecorator('fieldNText', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldNText"} id={"fieldNText"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldNumeric'>FieldNumeric</label>
              <br />             
              {getFieldDecorator('fieldNumeric', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldNumeric"} id={"fieldNumeric"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldNVarchar'>FieldNVarchar</label>
              <br />             
              {getFieldDecorator('fieldNVarchar', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldNVarchar"} id={"fieldNVarchar"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldReal'>FieldReal</label>
              <br />             
              {getFieldDecorator('fieldReal', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldReal"} id={"fieldReal"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldSmallDateTime'>FieldSmallDateTime</label>
              <br />             
              {getFieldDecorator('fieldSmallDateTime', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldSmallDateTime"} id={"fieldSmallDateTime"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldSmallInt'>FieldSmallInt</label>
              <br />             
              {getFieldDecorator('fieldSmallInt', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldSmallInt"} id={"fieldSmallInt"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldSmallMoney'>FieldSmallMoney</label>
              <br />             
              {getFieldDecorator('fieldSmallMoney', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldSmallMoney"} id={"fieldSmallMoney"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldText'>FieldText</label>
              <br />             
              {getFieldDecorator('fieldText', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldText"} id={"fieldText"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldTime'>FieldTime</label>
              <br />             
              {getFieldDecorator('fieldTime', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldTime"} id={"fieldTime"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldTimestamp'>FieldTimestamp</label>
              <br />             
              {getFieldDecorator('fieldTimestamp', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldTimestamp"} id={"fieldTimestamp"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldTinyInt'>FieldTinyInt</label>
              <br />             
              {getFieldDecorator('fieldTinyInt', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldTinyInt"} id={"fieldTinyInt"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldUniqueIdentifier'>FieldUniqueIdentifier</label>
              <br />             
              {getFieldDecorator('fieldUniqueIdentifier', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldUniqueIdentifier"} id={"fieldUniqueIdentifier"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldVarBinary'>FieldVarBinary</label>
              <br />             
              {getFieldDecorator('fieldVarBinary', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldVarBinary"} id={"fieldVarBinary"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldVarchar'>FieldVarchar</label>
              <br />             
              {getFieldDecorator('fieldVarchar', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldVarchar"} id={"fieldVarchar"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fieldXML'>FieldXML</label>
              <br />             
              {getFieldDecorator('fieldXML', {
              rules:[],
              
              })
              ( <Input placeholder={"FieldXML"} id={"fieldXML"} /> )}
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
    <Hash>18001d7ea59a208f602f20bcde9ae95e</Hash>
</Codenesium>*/