import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CallPersonMapper from './callPersonMapper';
import CallPersonViewModel from './callPersonViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface CallPersonCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface CallPersonCreateComponentState {
  model?: CallPersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class CallPersonCreateComponent extends React.Component<
  CallPersonCreateComponentProps,
  CallPersonCreateComponentState
> {
  state = {
    model: new CallPersonViewModel(),
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
        let model = values as CallPersonViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:CallPersonViewModel) =>
  {  
    let mapper = new CallPersonMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.CallPersons,
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
            Api.CallPersonClientRequestModel
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
              <label htmlFor='note'>note</label>
              <br />             
              {getFieldDecorator('note', {
              rules:[{ max: 8000, message: 'Exceeds max length of 8000' },
],
              
              })
              ( <Input placeholder={"note"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='personId'>personId</label>
              <br />             
              {getFieldDecorator('personId', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"personId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='personTypeId'>personTypeId</label>
              <br />             
              {getFieldDecorator('personTypeId', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"personTypeId"} /> )}
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

export const WrappedCallPersonCreateComponent = Form.create({ name: 'CallPerson Create' })(CallPersonCreateComponent);

/*<Codenesium>
    <Hash>d0b1b34513b392a46593139e2d18e983</Hash>
</Codenesium>*/