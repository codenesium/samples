import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import ChainStatusMapper from '../chainStatus/chainStatusMapper';
import ChainStatusViewModel from '../chainStatus/chainStatusViewModel';
import {
  Spin,
  Alert,
  Select
} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface ChainStatusSelectComponentProps {
  getFieldDecorator: any;
  apiRoute:string;
  selectedValue:number;
  propertyName:string;
  required:boolean;
}

interface ChainStatusSelectComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<ChainStatusViewModel>;
}

export class  ChainStatusSelectComponent extends React.Component<
ChainStatusSelectComponentProps,
ChainStatusSelectComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

  componentDidMount() {
   
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Array<Api.ChainStatusClientResponseModel>;

          console.log(response);

          let mapper = new ChainStatusMapper();
          
          let devices:Array<ChainStatusViewModel> = [];

          response.forEach(x =>
          {
              devices.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: devices,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    

    
	let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
       return <Spin size="large" />;
    }
    else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type='error' />;
    }
	  else if (this.state.loaded) {
      return (
        <div>
        {
          this.props.getFieldDecorator(this.props.propertyName, {
          initialValue: this.props.selectedValue,
          rules: [{ required: this.props.required, message: 'Required' }],
        })(
          <Select>
          {
            this.state.filteredRecords.map((x:ChainStatusViewModel) =>
            {
                return <Select.Option value={x.id}>{x.toDisplay()}</Select.Option>;
            })
          }
          </Select>
        )
      }
      </div>
    );
    } else {
      return null;
    }
  }
}

/*<Codenesium>
    <Hash>0e14fd64fb9d41731f3423e8de88d4bd</Hash>
</Codenesium>*/