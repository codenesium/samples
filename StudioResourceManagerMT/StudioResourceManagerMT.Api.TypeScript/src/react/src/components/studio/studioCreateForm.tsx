import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import StudioMapper from './studioMapper';
import StudioViewModel from './studioViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface StudioCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface StudioCreateComponentState {
  model?: StudioViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class StudioCreateComponent extends React.Component<
  StudioCreateComponentProps,
  StudioCreateComponentState
> {
  state = {
    model: new StudioViewModel(),
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
        let model = values as StudioViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:StudioViewModel) =>
  {  
    let mapper = new StudioMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Studios,
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
            Api.StudioClientRequestModel
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
              <label htmlFor='address1'>address1</label>
              <br />             
              {getFieldDecorator('address1', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"address1"} id={"address1"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='address2'>address2</label>
              <br />             
              {getFieldDecorator('address2', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"address2"} id={"address2"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='city'>city</label>
              <br />             
              {getFieldDecorator('city', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"city"} id={"city"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='name'>name</label>
              <br />             
              {getFieldDecorator('name', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"name"} id={"name"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='province'>province</label>
              <br />             
              {getFieldDecorator('province', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"province"} id={"province"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='website'>website</label>
              <br />             
              {getFieldDecorator('website', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"website"} id={"website"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='zip'>zip</label>
              <br />             
              {getFieldDecorator('zip', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"zip"} id={"zip"} /> )}
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

export const WrappedStudioCreateComponent = Form.create({ name: 'Studio Create' })(StudioCreateComponent);

/*<Codenesium>
    <Hash>db5301bebe2189793aa40d034ba3bd42</Hash>
</Codenesium>*/