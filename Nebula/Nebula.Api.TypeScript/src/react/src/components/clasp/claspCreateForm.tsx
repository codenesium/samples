import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ClaspMapper from './claspMapper';
import ClaspViewModel from './claspViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ChainSelectComponent } from '../shared/chainSelect'
	
interface ClaspCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface ClaspCreateComponentState {
  model?: ClaspViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class ClaspCreateComponent extends React.Component<
  ClaspCreateComponentProps,
  ClaspCreateComponentState
> {
  state = {
    model: new ClaspViewModel(),
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
        let model = values as ClaspViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:ClaspViewModel) =>
  {  
    let mapper = new ClaspMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Clasps,
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
            Api.ClaspClientRequestModel
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
              <label htmlFor='nextChainId'>NextChainId</label>
              <br />             
              {getFieldDecorator('nextChainId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"NextChainId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='previousChainId'>PreviousChainId</label>
              <br />             
              {getFieldDecorator('previousChainId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"PreviousChainId"} /> )}
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

export const WrappedClaspCreateComponent = Form.create({ name: 'Clasp Create' })(ClaspCreateComponent);

/*<Codenesium>
    <Hash>f35bc1a53276dccce976322e29fb1ffa</Hash>
</Codenesium>*/